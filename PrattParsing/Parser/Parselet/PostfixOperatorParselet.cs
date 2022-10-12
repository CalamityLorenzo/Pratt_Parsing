using PrattParsing.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParsing.Parser.Parselet
{
    internal record PostfixOperatorParselet : InfixParselet
    {
        private int _precedence;

        public PostfixOperatorParselet(int precedence) => this._precedence = precedence;

        public int GetPrecedence() => this._precedence;

        public Expression Parse(PrattParser parser, Expression left, LexerToken token)
        {
            return new PostfixExpression(left, token.Type);
        }
    }
}
