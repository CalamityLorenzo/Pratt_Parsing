using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrattParsing
{
    public class PrattParser
    {
        private List<LexerToken> _tokens;
        internal int _currentPosition;
        internal int _nextPosition;

        List<Expression> _Ast = new List<Expression>();

        public PrattParser(PrattLexer l)
        {
            this._tokens = l.GetTokens().ToList();
            this.MoveNextToken();
        }

        public List<Expression> Parse()
        {
            while (!AtEnd())
            {
                ParseExpression();
            }
            return _Ast;
        }

        private void ParseExpression()
        {
            // There will be a switch!

            MoveNextToken();
        }

        private void MoveNextToken()
        {
            if (!AtEnd())
            {
                this._currentPosition = _nextPosition;
                _nextPosition += 1;
            }
        }

        private bool AtEnd()
        {
            if (_nextPosition >= this._tokens.Count) return true;

            return false;
        }
        
    }
}
