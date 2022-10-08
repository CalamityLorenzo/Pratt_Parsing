using PrattParsing.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParsing.Parser
{
    internal record PrefixOperatorParselet : PrefixParselet
    {
        public Expression Parse(PrattParser parser, LexerToken token)
        {
            // the sound of the machinery moving one step along
            Expression operand = parser.ParseExpression();

            return new PrefixExpression(token.type, operand);
        }
    }
}
