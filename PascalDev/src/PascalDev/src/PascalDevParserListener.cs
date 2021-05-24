using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using JetBrains.ReSharper.Psi.TreeBuilder;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    public class PascalDevParserListener : PascalParserBaseListener
    {
        private readonly PsiBuilder _builder;
        private readonly Stack<int> _marks = new Stack<int>();

        public PascalDevParserListener(PsiBuilder builder)
        {
            _builder = builder;
        }

        public override void VisitTerminal(ITerminalNode node)
        {
            if (_builder.Eof()) return;
            do
            {
                _builder.AdvanceLexer();
            } while (!_builder.Eof() && (_builder.GetTokenType().IsComment || _builder.GetTokenType().IsWhitespace));
        }

        public override void EnterEveryRule(ParserRuleContext ctx)
        {
            _marks.Push(_builder.Mark());
        }

        public override void ExitEveryRule(ParserRuleContext ctx)
        {
            _builder.Done(_marks.Pop(), PascalDevCompositeNodeType.BLOCK, null);
        }
    }
}