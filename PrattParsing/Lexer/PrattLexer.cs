using System.Transactions;
using static PrattParsing.Lexer.LexerTokenType;

namespace PrattParsing.Lexer
{
    public class PrattLexer
    {
        private int currentPosition;
        private int NextPosition;
        private readonly string rawInput;

        private List<LexerToken> Tokens = new List<LexerToken>();

        public int TokenStartIdx { get; private set; }

        public PrattLexer(string input)
        {
            currentPosition = 0;
            NextPosition = 1;
            rawInput = input! + '\0';
        }

        public void MoveNextPosition()
        {
            if (NextPosition <= rawInput.Length)
            {
                currentPosition = NextPosition;
                NextPosition += 1;
            }
        }

        public IEnumerable<LexerToken> GetTokens()
        {
            while (!AtInputEnd())
            {
                Read();
            }
            return Tokens;
        }

        private void Read()
        {
            var curChar = rawInput[currentPosition];
            // Each time we loop this is reset.
            TokenStartIdx = currentPosition;
            switch (curChar)
            {
                case '+':
                    if (Match('+'))
                        Tokens.Add(CreateToken(PLUS_PLUS));
                    else
                        Tokens.Add(CreateToken(PLUS));
                    break;
                case '-':
                    if (Match('-'))
                        Tokens.Add(CreateToken(MINUS_MINUS));
                    else
                        Tokens.Add(CreateToken(MINUS));
                    break;
                case '=':
                    if (Match('='))
                        Tokens.Add(CreateToken(EQUALS));
                    else
                        Tokens.Add(CreateToken(ASSIGN));
                    break;
                case '!':
                    if (Match('='))
                        Tokens.Add(CreateToken(BANG_EQUALS));
                    else
                        Tokens.Add(CreateToken(BANG));
                    break;
                case '*':
                    Tokens.Add(CreateToken(ASTERISK));
                    break;
                case '/':
                    if (Match('/'))
                    {
                        MapComment();
                        Tokens.Add(CreateToken(COMMENT));
                    }
                    else
                        Tokens.Add(CreateToken(SLASH));
                    break;
                case '%':
                    Tokens.Add(CreateToken(MOD));
                    break;
                case '~':
                    Tokens.Add(CreateToken(TILDE));
                    break;
                case '^':
                    Tokens.Add(CreateToken(CARET));
                    break;
                case '(':
                    Tokens.Add(CreateToken(LEFT_PARENS));
                    break;
                case ')':
                    Tokens.Add(CreateToken(RIGHT_PARENS));
                    break;
                case '{':
                    Tokens.Add(CreateToken(LEFT_BRACE));
                    break;
                case '}':
                    Tokens.Add(CreateToken(RIGHT_BRACE));
                    break;
                case '?':
                    Tokens.Add(CreateToken(QUESTION_MARK));
                    break;
                case ':':
                    Tokens.Add(CreateToken(COLON));
                    break;
                case ';':
                    Tokens.Add(CreateToken(SEMI_COLON));
                    break;
                case '\0':
                    Tokens.Add(CreateToken(EOF));
                    break;
                case ' ': // don't care about the whitespace
                case '\r':
                case '\n':
                    break;
                default:
                    if (char.IsDigit(curChar))
                    {
                        MapNumber();
                        Tokens.Add(CreateToken(INT));
                    }
                    else if (char.IsLetter(curChar) || curChar == '_' && char.IsLetterOrDigit(Peek()))
                    {
                        MapLiteral();
                        Tokens.Add(CreateToken(LITERAL));
                    }
                    break;


            }
            MoveNextPosition();

        }

        /// <summary>
        /// Comments are like this. except with two slashes. They are terminated by an eof.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void MapComment()
        {
            // Keep on the trucking!
            var p = Peek();
            while (!AtInputEnd() && p != '\0' && p != '\r' && p != '\n')
            {
                MoveNextPosition();
                p = Peek();
            }
        }

        private LexerToken CreateToken(LexerTokenType type)
        {
            var rangeLength = currentPosition - TokenStartIdx + (!AtInputEnd() ? 1 : 0);
            return new LexerToken(type, rawInput[TokenStartIdx..(TokenStartIdx + rangeLength)]);
        }

        /// <summary>
        /// Processes the stream until we reach the end of a number
        /// TODO: the while loop is clumsy, as is the constant string allocation.
        /// Need a FinishIdx-StartIdx mechanism so we only allocate once.
        /// </summary>
        /// <returns></returns>
        private void MapNumber()
        {
            //var literal = new String(new char[] { this.rawInput[currentPosition] });
            while (!AtInputEnd() && char.IsDigit(Peek()))
            {
                MoveNextPosition();
            }
        }

        private bool AtInputEnd() => currentPosition >= rawInput.Length;

        private void MapLiteral()
        {
            // We already are in the literal at thisPoint
            // so we are just determining the length
            while (!AtInputEnd() && IsLiteralChar(Peek()) && Peek() != '\0')
            {
                MoveNextPosition();
            }

        }

        private bool IsLiteralChar(char c) => char.IsLetterOrDigit(c) || c == '_';

        private char Peek()
        {
            if (NextPosition >= rawInput.Length)
                return '\0';
            else
                return rawInput[NextPosition];
        }

        private bool Match(char matchChar)
        {
            if (AtInputEnd()) return false;

            if (Peek() == matchChar)
            {
                MoveNextPosition();
                return true;
            }

            return false;
        }
    }
}
