using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using JetBrains.Application.Settings;
using JetBrains.DocumentModel;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Feature.Services.SelectEmbracingConstruct;
using JetBrains.ReSharper.I18n.Services.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Parsing;
using JetBrains.ReSharper.Psi.ExtensionsAPI;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.TreeBuilder;
using JetBrains.Text;
using Antlr4.Runtime;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    internal class PascalDevParser : IParser
    {
        private readonly ILexer myLexer;

        public PascalDevParser(ILexer lexer)
        {
            myLexer = lexer;
        }

        public IFile ParseFile()
        {
            using (var def = Lifetime.Define())
            {
                var builder = new PsiBuilder(myLexer, PascalDevFileNodeType.Instance, new TokenFactory(), def.Lifetime);
                var fileMark = builder.Mark();

                ParseBlock(builder);

                builder.Done(fileMark, PascalDevFileNodeType.Instance, null);
                var file = (IFile)builder.BuildTree();
                return file;
            }
        }

        private void ParseBlock(PsiBuilder builder)
        {
            var parser = new PascalParser(new CommonTokenStream(
                new PascalLexer(new AntlrInputStream(myLexer.Buffer.GetText()))));
            parser.AddParseListener(new PascalDevParserListener(builder));
            parser.AddErrorListener(new PascalDevErrorListener(builder));
            parser.program();
        }
    }

    [DaemonStage]
    class PascalDevDaemonStage : DaemonStageBase<PascalDevFile>
    {
        protected override IDaemonStageProcess CreateDaemonProcess(IDaemonProcess process, DaemonProcessKind processKind, PascalDevFile file,
            IContextBoundSettingsStore settingsStore)
        {
            return new PascalDevDaemonProcess(process, file);
        }

        internal class PascalDevDaemonProcess : IDaemonStageProcess
        {
            private readonly PascalDevFile myFile;
            public PascalDevDaemonProcess(IDaemonProcess process, PascalDevFile file)
            {
                myFile = file;
                DaemonProcess = process;
            }

            public void Execute(Action<DaemonStageResult> committer)
            {
                var highlightings = new List<HighlightingInfo>();
                foreach (var treeNode in myFile.Descendants())
                {
                    if (treeNode is PsiBuilderErrorElement error)
                    {
                        var range = error.GetDocumentRange();
                        highlightings.Add(new HighlightingInfo(range, new CSharpSyntaxError(error.ErrorDescription, range)));
                    }
                }
                
                var result = new DaemonStageResult(highlightings);
                committer(result);
            }

            public IDaemonProcess DaemonProcess { get; }
        }

        protected override IEnumerable<PascalDevFile> GetPsiFiles(IPsiSourceFile sourceFile)
        {
            yield return (PascalDevFile)sourceFile.GetDominantPsiFile<PascalDevLanguage>();
        }
    } 

    internal class TokenFactory : IPsiBuilderTokenFactory
    {
        public LeafElementBase CreateToken(TokenNodeType tokenNodeType, IBuffer buffer, int startOffset, int endOffset)
        {
            return tokenNodeType.Create(buffer, new TreeOffset(startOffset), new TreeOffset(endOffset));
        }
    }

    [ProjectFileType(typeof (PascalDevProjectFileType))]
    public class SelectEmbracingConstructProvider : ISelectEmbracingConstructProvider
    {
        public bool IsAvailable(IPsiSourceFile sourceFile)
        {
            return sourceFile.LanguageType.Is<PascalDevProjectFileType>();
        }

        public ISelectedRange GetSelectedRange(IPsiSourceFile sourceFile, DocumentRange documentRange)
        {
            var file = (PascalDevFile) sourceFile.GetDominantPsiFile<PascalDevLanguage>();
            var node = file.FindNodeAt(documentRange);
            return new PascalDevTreeNodeSelection(file, node);
        }

        public class PascalDevTreeNodeSelection : TreeNodeSelection<PascalDevFile>
        {
            public PascalDevTreeNodeSelection(PascalDevFile fileNode, ITreeNode node) : base(fileNode, node)
            {
            }

            public override ISelectedRange Parent => new PascalDevTreeNodeSelection(FileNode, TreeNode.Parent);
        }
    }
}
