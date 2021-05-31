using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;
using JetBrains.Util;
using System.Text;
using JetBrains.ReSharper.Psi.Tree;


namespace JetBrains.ReSharper.Plugins.PascalDev
{
    class PascalDevTokenType : TokenNodeType
    {
        // public static  PascalDevTokenType EQ = new PascalDevTokenType("EQ", 0);
        // public static  PascalDevTokenType NUMBER = new PascalDevTokenType("NUMBER", 1);
        // public static PascalDevTokenType STRING = new PascalDevTokenType("STRING", 2);
        // public static PascalDevTokenType BAD_CHARACTER = new PascalDevTokenType("BAD_CHARACTER", 3);
        public PascalDevTokenType(string s, int index) : base(s, index)
        {
        }

        public override LeafElementBase Create(IBuffer buffer, TreeOffset startOffset, TreeOffset endOffset)
        {
            return new PascalDevToken(buffer.GetText(new TextRange(startOffset.Offset, endOffset.Offset)), this);
        }

        public override bool IsWhitespace => Index == PascalLexer.Whitespace;
        public override bool IsComment => Index == PascalLexer.Comment;
        public override bool IsStringLiteral => Index == PascalLexer.CharacterString;
        public override bool IsConstantLiteral => Index == PascalLexer.Number;
        public override bool IsIdentifier => Index == PascalLexer.Identifier;

        public override bool IsKeyword => new[]
        {
            PascalLexer.Nil, PascalLexer.Begin, PascalLexer.End,
            PascalLexer.Goto, PascalLexer.Not, PascalLexer.Signum,
            PascalLexer.Case, PascalLexer.Of, PascalLexer.Else,
            PascalLexer.Otherwise, PascalLexer.If, PascalLexer.Then,
            PascalLexer.For, PascalLexer.To, PascalLexer.Downto,
            PascalLexer.Do, PascalLexer.Repeat, PascalLexer.Until,
            PascalLexer.While, PascalLexer.With, PascalLexer.Or,
            PascalLexer.Xor, PascalLexer.Div, PascalLexer.Mod,
            PascalLexer.And, PascalLexer.Shl, PascalLexer.Shr,
            PascalLexer.As, PascalLexer.In, PascalLexer.Is
        }.Contains(Index);
        public override string TokenRepresentation => ToString();
    }
    
    class PascalDevToken : LeafElementBase, ITokenNode
    {
        private readonly string _text;
        private readonly PascalDevTokenType _pascalDevTokenType;

        public PascalDevToken(string givenText, PascalDevTokenType givenPascalDevTokenType)
        {
            _text = givenText;
            _pascalDevTokenType = givenPascalDevTokenType;
        }

        public override int GetTextLength()
        {
            return _text.Length;
        }

        public override StringBuilder GetText(StringBuilder to)
        {
            return to.Append(_text);
        }

        public override IBuffer GetTextAsBuffer()
        {
            return new StringBuffer(_text);
        }

        public override string GetText()
        {
            return _text;
        }

        public override NodeType NodeType => _pascalDevTokenType;
        public override PsiLanguageType Language => PascalDevLanguage.Instance;
        public TokenNodeType GetTokenType() => _pascalDevTokenType;
    }
}