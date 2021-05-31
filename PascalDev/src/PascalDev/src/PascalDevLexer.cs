using Antlr4.Runtime;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;

namespace JetBrains.ReSharper.Plugins.PascalDev
{
    public class PascalDevLexerState
    {
        public readonly IToken Token;
        public readonly int Type;
        public readonly int Channel;
        public readonly int Column;
        public readonly int Line;
        public readonly string Text;
        public readonly bool HitEof;
        public readonly int CurrentMode;
        public readonly int[] ModeStack;

        public PascalDevLexerState(Lexer lexer)
        {
            Token = lexer.Token;
            Type = lexer.Type;
            Channel = lexer.Channel;
            Column = lexer.Column;
            Line = lexer.Line;
            Text = lexer.Text;
            HitEof = lexer.HitEOF;
            CurrentMode = lexer.CurrentMode;
            ModeStack = lexer.ModeStack?.ToArray();
        }
    }
    
    public class PascalDevLexer : ILexer<PascalDevLexerState>
    {
        private readonly Lexer _lexer;
        private IToken _currentToken;

        public PascalDevLexer(IBuffer buffer)
        {
            Buffer = buffer;
            _lexer = new PascalLexer(new AntlrInputStream(buffer.GetText()));
        }

        public void Start()
        {
            Advance();
            CurrentPosition = new PascalDevLexerState(_lexer);
        }

        public void Advance()
        {
            _currentToken = _lexer.HitEOF ? null : _lexer.NextToken();
            CurrentPosition = new PascalDevLexerState(_lexer);
        }

        public PascalDevLexerState CurrentPosition
        {
            get => new PascalDevLexerState(_lexer);
            set
            {
                _lexer.Token = value.Token;
                _lexer.Type = value.Type;
                _lexer.Channel = value.Channel;
                _lexer.Column = value.Column;
                _lexer.Line = value.Line;
                _lexer.Text = value.Text;
                _lexer.HitEOF = value.HitEof;
                _lexer.CurrentMode = value.CurrentMode;
                _lexer.ModeStack.Clear();
                foreach (var mode in value.ModeStack ?? new int[] { })
                {
                    _lexer.ModeStack.Push(mode);
                }
            }
        }

        object ILexer.CurrentPosition
        {
            get => CurrentPosition;
            set => CurrentPosition = (PascalDevLexerState) value;
        }

        public TokenNodeType TokenType =>
            _currentToken == null ? null : new PascalDevTokenType(_currentToken.Text, _currentToken.Type);

        public int TokenStart => _currentToken.StartIndex;
        public int TokenEnd => _currentToken.StopIndex + 1;
        public IBuffer Buffer { get; }
    }
}