using System.Collections.Generic;
using Antlr4.Runtime;

namespace IDE_dev
{
    public static class Lexer
    {
        public static IEnumerable<IToken> Lex(string input)
        {
            var tokens = new CommonTokenStream(new Pascal(new AntlrInputStream(input)));
            tokens.Fill();
            return tokens.GetTokens();
        }
    }
}