using PrattParsing.Lexer;
using static PrattParsing.Lexer.LexerTokenType;
namespace PrattParsing.Parser
{
    public class PrattParser
    {
        private List<LexerToken> _tokens;
        internal int _currentPosition;
        internal int _nextPosition;

        List<Expression> _Ast = new List<Expression>();

        private Dictionary<LexerTokenType, PrefixParselet> _prefixParselets = new()
        {
            { LITERAL, new NameParselet() },
            { PLUS, new PrefixOperatorParselet() },
            { MINUS, new PrefixOperatorParselet() },
            { BANG, new PrefixOperatorParselet() },
            { TILDE, new PrefixOperatorParselet() },
        };

        public PrattParser(PrattLexer l)
        {
            _tokens = l.GetTokens().ToList();
            MoveNextToken();
        }

        public List<Expression> Parse()
        {
            while (!AtEnd())
            {
                this._Ast.Add(
                ParseExpression()
                );
            }
            return _Ast;
        }

        public Expression ParseExpression()
        {
            LexerToken token = this.Consume();

            if (token.type == INT)
                return new NumberExpression(token.literal, int.Parse(token.literal));
            else
            {
                var prefix = this._prefixParselets[token.type];
                return prefix.Parse(this, token);
            }
        }

        private LexerToken Consume()
        {
            if(!AtEnd())  return _tokens[_currentPosition++];
            throw new ArgumentOutOfRangeException("Reached end of tokens");
        }

        private void MoveNextToken()
        {
            if (!AtEnd())
            {
                _currentPosition = _nextPosition;
                _nextPosition += 1;
            }
        }

        private bool AtEnd()
        {
            if (_currentPosition >= _tokens.Count) return true;
            return false;
        }

    }
}
