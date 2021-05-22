namespace IDE_dev
{
    public static class TokenType
    {
        public const int Number = Pascal.Number;
        public const int Identifier = Pascal.Identifier;
        public const int CharacterString = Pascal.CharacterString;
        public const int Comment = Pascal.Comment;
        public const int Symbol = Pascal.Symbol;

        public const int Semicolon = Pascal.SEMICOLON;
        public const int LBrace = Pascal.LBRC;
        public const int RBrace = Pascal.RBRC;
        public const int Dot = Pascal.DOT;
        public const int EqualSign = Pascal.EQL;

        public const int Whitespace = Pascal.Whitespace;
        public const int Eof = Pascal.Eof;
        public const int Error = Pascal.Error;
    }
}