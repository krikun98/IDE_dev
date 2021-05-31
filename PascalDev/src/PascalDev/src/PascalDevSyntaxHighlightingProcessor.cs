using JetBrains.ReSharper.Daemon.SyntaxHighlighting;
using JetBrains.ReSharper.Host.Features.SyntaxHighlighting;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Parsing;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    [Language(typeof(PascalDevLanguage))]
    internal class PascalDevSyntaxHighlightingManager : RiderSyntaxHighlightingManager
    {
        public override SyntaxHighlightingProcessor CreateProcessor()
        {
            return new PascalDevSyntaxHighlightingProcessor();
        }
    }

    
    class PascalDevSyntaxHighlightingProcessor : SyntaxHighlightingProcessor
    {
        protected override bool IsBlockComment(TokenNodeType tokenType)
        {
            return base.IsBlockComment(tokenType);
        }

        protected override bool IsLineComment(TokenNodeType tokenType)
        {
            return base.IsLineComment(tokenType);
        }

        protected override bool IsString(TokenNodeType tokenType)
        {
            return base.IsString(tokenType);
        }

        protected override bool IsNumber(TokenNodeType tokenType)
        {
            return base.IsNumber(tokenType);
        }

        protected override bool IsKeyword(TokenNodeType tokenType)
        {
            return base.IsKeyword(tokenType) || tokenType.IsConstantLiteral;
        }
    }
}