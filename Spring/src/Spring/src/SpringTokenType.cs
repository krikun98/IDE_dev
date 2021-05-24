using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;
using JetBrains.Util;
using System.Text;
using JetBrains.ReSharper.Psi.Tree;


namespace JetBrains.ReSharper.Plugins.Spring
{
    class SpringTokenType : TokenNodeType
    {
        // public static  SpringTokenType EQ = new SpringTokenType("EQ", 0);
        // public static  SpringTokenType NUMBER = new SpringTokenType("NUMBER", 1);
        // public static SpringTokenType STRING = new SpringTokenType("STRING", 2);
        // public static SpringTokenType BAD_CHARACTER = new SpringTokenType("BAD_CHARACTER", 3);
        public SpringTokenType(string s, int index) : base(s, index)
        {
        }

        public override LeafElementBase Create(IBuffer buffer, TreeOffset startOffset, TreeOffset endOffset)
        {
            return new SpringToken(buffer.GetText(new TextRange(startOffset.Offset, endOffset.Offset)), this);
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
    
    class SpringToken : LeafElementBase, ITokenNode
    {
        private readonly string text;
        private readonly SpringTokenType springTokenType;

        public SpringToken(string givenText, SpringTokenType givenSpringTokenType)
        {
            text = givenText;
            springTokenType = givenSpringTokenType;
        }

        public override int GetTextLength()
        {
            return text.Length;
        }

        public override StringBuilder GetText(StringBuilder to)
        {
            return to.Append(text);
        }

        public override IBuffer GetTextAsBuffer()
        {
            return new StringBuffer(text);
        }

        public override string GetText()
        {
            return text;
        }

        public override NodeType NodeType => springTokenType;
        public override PsiLanguageType Language => SpringLanguage.Instance;
        public TokenNodeType GetTokenType() => springTokenType;
    }
}