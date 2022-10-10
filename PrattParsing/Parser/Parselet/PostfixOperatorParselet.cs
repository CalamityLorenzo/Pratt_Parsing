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
        public Expression Parse(PrattParser parser, Expression left, LexerToken token)
        {
            return new PostfixExpression(left, token.Type);
        }
    }
}
