namespace PrattParsing
{
    public class PrattLexer
    {
        private int currentPosition;
        private int NextPosition;
        private readonly string rawInput;

        private List<LexerToken> Tokens = new List<LexerToken>();

        public PrattLexer(string input)
        {
            this.currentPosition = 0;
            this.NextPosition = 1;
            this.rawInput = input!;
        }

        public void MoveNextPosition()
        {
            this.currentPosition = NextPosition;
            if (NextPosition + 1 < rawInput.Length)
                NextPosition += 1;
        }

        public IEnumerable<LexerToken> GetTokens()
        {
            while (this.currentPosition < rawInput.Length)
            {
                Read();
            }

            return this.Tokens;

        }

        private void Read()
        {
            var curChar = rawInput[currentPosition];
            switch (curChar)
            {
                case '+':
                    if (this.Peek() == '+')
                        Tokens.Add(new LexerToken(LexerTokenType.PLUS_PLUS, "++"));
                    else
                        Tokens.Add(new LexerToken(LexerTokenType.PLUS, new String(new char[] { curChar })));
                    break;
                case '-':
                    if (this.Peek() == '-')
                        Tokens.Add(new LexerToken(LexerTokenType.MINUS_MINUS, "--"));
                    else
                        Tokens.Add(new LexerToken(LexerTokenType.MINUS, "-"));
                    break;
                case '=':
                    if (this.Peek() == '=')
                        Tokens.Add(new LexerToken(LexerTokenType.EQUALS, "=="));
                    else
                        Tokens.Add(new LexerToken(LexerTokenType.ASSIGN, "="));
                    break;
                case '!':
                    if (this.Peek() == '=')
                        Tokens.Add(new LexerToken(LexerTokenType.BANG_EQUALS, "!="));
                    else
                        Tokens.Add(new LexerToken(LexerTokenType.BANG, "!"));
                    break;
                case '*':
                    Tokens.Add(new LexerToken(LexerTokenType.ASTERISK, "*"));
                    break;
                case '/':
                    Tokens.Add(new LexerToken(LexerTokenType.SLASH, "/"));
                    break;
                case '(':
                    Tokens.Add(new LexerToken(LexerTokenType.LEFT_PARENS, "("));
                    break;
                case ')':
                    Tokens.Add(new LexerToken(LexerTokenType.RIGHT_PARENS, ")"));
                    break;
                case '{':
                    Tokens.Add(new LexerToken(LexerTokenType.LEFT_BRACE, "{"));
                    break;
                case '}':
                    Tokens.Add(new LexerToken(LexerTokenType.RIGHT_BRACE, "}"));
                    break;
                case '?':
                    Tokens.Add(new LexerToken(LexerTokenType.QUESTION_MARK, "?"));
                    break;
                case ':':
                    Tokens.Add(new LexerToken(LexerTokenType.COLON, ":"));
                    break;
                case ';':
                    Tokens.Add(new LexerToken(LexerTokenType.SEMI_COLON, ":"));
                    break;
                case '0':
                    Tokens.Add(new LexerToken(LexerTokenType.EOF, ""));
                    break;
                case ' ': // don't care about the whitespace
                case '\r':
                case '\n':
                    break;


            }

            this.MoveNextPosition());

        }

        private char Peek()
        {
            if (NextPosition < rawInput.Length - 1)
                return rawInput[NextPosition];
            else
                return '0';
        }

        private bool Match(char matchChar)
        {
            if (this.Peek() == matchChar)
            {
                this.MoveNextPosition();
                return true;
            }

            return false;
        }
    }
}
