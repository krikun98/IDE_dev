using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace IDE_dev
{
    public class PascalTests
    {
        private static void AssertTokenType(List<string> inputs, int tokenType)
        {
            inputs.ForEach(input => CollectionAssert.AreEqual(
                new[] {tokenType, TokenType.Eof},
                Lexer.Lex(input).Select(t => t.Type)));
        }

        private static void AssertTokenTypes(string input, IEnumerable<int> tokenTypes)
        {
            CollectionAssert.AreEqual(
                tokenTypes,
                Lexer.Lex(input).Select(t => t.Type));
        }


        private static void AssertNotTokenType(List<string> inputs, int tokenType)
        {
            inputs.ForEach(input => CollectionAssert.AreNotEqual(
                new[] {tokenType, TokenType.Eof},
                Lexer.Lex(input).Select(t => t.Type)));
        }
        
        /*[Test]
        public void TestSymbols()
        {
            AssertTokenType(new List<string>
            {
                "3", "s", "S", "1", "A", "f"
            }, TokenType.Symbol);
            AssertNotTokenType(new List<string>
            {
                "+", "=", "%"
            }, TokenType.Symbol);
        }*/ // Other tokens seem to take precedence

        [Test]
        public void TestComments()
        {
            AssertTokenType(new List<string>
            {
                "(* This is an old style comment *)",
                "{  This is a Turbo Pascal comment }",
                "// This is a Delphi comment. All is ignored till the end of the line.",
                "{  My beautiful function returns an interesting result, \n but only if the argument A is less than B.}",
                "{ Comment 1 (* comment 2 *) }",
                "(* Comment 1 { comment 2 } *)",
                "{ comment 1 // Comment 2 }",
                "(* comment 1 // Comment 2 *)",
                "// comment 1 (* comment 2 *)",
                "// comment 1 { comment 2 }"
            }, TokenType.Comment);
            AssertNotTokenType(new List<string>
            {
                "// Valid comment { No longer valid comment !! \n}"
            }, TokenType.Comment);
        }

        [Test]
        public void TestIdentifiers()
        {
            AssertTokenType(new List<string>
            {
                "_", "_x", "a", "x_1", "_42", "l33t", "anId", "I"
            }, TokenType.Identifier);
            AssertNotTokenType(new List<string>
            {
                "1", "an.id", "_id3nt1f13?"
                
            }, TokenType.Identifier);
        }

        [Test]
        public void TestNumbers()
        {
            AssertTokenType(new List<string>
            {
                "42", "$ABC", "&72", "%101", "-1", "-0.3", "+1", "0.4E5", "0.2e3", "42E2"
            }, TokenType.Number);
            AssertNotTokenType(new List<string>
            {
                "%2", "&9", "$G", "$-0", "-", "$", "%", "&", ".2", "F", "%F", "0.3E", "E"
            }, TokenType.Number);
        }

        [Test]
        public void TestCharacterStrings()
        {
            AssertTokenType(new List<string>
            {
                "''", "''''", "'This is a pascal string'", "'A tabulator character: '#9' is easy to embed'",
                "'the string starts here'#13#10'   and continues here'"
            }, TokenType.CharacterString);
            AssertNotTokenType(new List<string>
            {
                "'''", "'\\''", "'the string starts here \n and continues here'"
            }, TokenType.CharacterString);
        }

        [Test]
        public void TestProgramExample()
        {
            AssertTokenTypes(@"// Hello world in Pascal
program x (x);

type
  T = record end;

{ Sample multiline
comment }

begin
  writeln('Hello world!');
end.", new[]
            {
                TokenType.Comment, TokenType.Whitespace,
                
                TokenType.Identifier, TokenType.Whitespace, TokenType.Identifier, TokenType.Whitespace,
                TokenType.LBrace, TokenType.Identifier, TokenType.RBrace, TokenType.Semicolon, TokenType.Whitespace, 
                
                TokenType.Identifier, TokenType.Whitespace, 
                
                TokenType.Identifier, TokenType.Whitespace, TokenType.EqualSign, TokenType.Whitespace,
                TokenType.Identifier, TokenType.Whitespace, TokenType.Identifier, TokenType.Semicolon, TokenType.Whitespace,
                
                TokenType.Comment, TokenType.Whitespace,

                TokenType.Identifier, TokenType.Whitespace, 
                
                TokenType.Identifier, TokenType.LBrace, TokenType.CharacterString, TokenType.RBrace, 
                TokenType.Semicolon, TokenType.Whitespace,
                
                TokenType.Identifier, TokenType.Dot, TokenType.Eof
            });
        }
    }
}