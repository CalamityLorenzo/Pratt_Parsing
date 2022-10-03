namespace PrattParsing
{
    public class PrattLexer
    {
        private int currentPosition;
        private int NextPosition;
        private readonly string rawInput;

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
            var tokens = new List<LexerToken>();
            while (this.currentPosition < rawInput.Length)
            {
                tokens.Add(Read(rawInput[currentPosition]));
            }

            return tokens;
        }

        private LexerToken Read(char curChar)
        {
            switch (curChar)
            {
                case '+':
                    if (this.Peek() == '+')
                        return new LexerToken(LexerTokenType.PLUS_PLUS, "++");
                    else
                        return new LexerToken(LexerTokenType.PLUS, new String(new char[] { curChar }));
                    break;
                case '-':
                    if (this.Peek() == '-')
                        return new LexerToken(LexerTokenType.MINUS_MINUS, "--");
                    else
                        return new LexerToken(LexerTokenType.MINUS, "-");
                    break;
                case '=':
                    if (this.Peek() == '=')
                        return new LexerToken(LexerTokenType.EQUALS, "==");
                    else
                        return new LexerToken(LexerTokenType.ASSIGN, "=");
                    break;
                case '!':
                    if (this.Peek() == '=')
                        return new LexerToken(LexerTokenType.BANG_EQUALS, "!=");
                    else
                        return new LexerToken(LexerTokenType.BANG, "!");
                case '*':
                    return new LexerToken(LexerTokenType.ASTERISK, "*");
                case '/':
                    return new LexerToken(LexerTokenType.SLASH, "/");
                case '(':
                    return new LexerToken(LexerTokenType.LEFT_PARENS, "(");
                case ')':
                    return new LexerToken(LexerTokenType.RIGHT_PARENS, ")");
                case '{':
                    return new LexerToken(LexerTokenType.LEFT_BRACE, "{");
                case '}':
                    return new LexerToken(LexerTokenType.RIGHT_BRACE, "}");
                case '?':
                    return new LexerToken(LexerTokenType.QUESTION_MARK, "?");
                case ':':
                    return new LexerToken(LexerTokenType.COLON, ":");
                case ';':
                    return new LexerToken(LexerTokenType.SEMI_COLON, ":");
                case '0':
                    return new LexerToken(LexerTokenType.EOF, "");
                




            }
        }

        private char Peek()
        {
            if (NextPosition < rawInput.Length - 1)
                return rawInput[NextPosition];
            else
                return '0';
        }
    }
