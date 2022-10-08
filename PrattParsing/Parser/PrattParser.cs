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
            var token = _tokens[_currentPosition];
            var _astToken = token.type switch
            {
                LITERAL => new NameExpression(token.literal),
                _ => throw new ArgumentOutOfRangeException($"Cannot find ast for token {token.type}")
            };
            MoveNextToken();
            return _astToken;
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
            if (_nextPosition >= _tokens.Count) return true;
            return false;
        }

    }
}
