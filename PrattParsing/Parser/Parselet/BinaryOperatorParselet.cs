using PrattParsing.Lexer;
using System.Security.AccessControl;

namespace PrattParsing.Parser.Parselet
{
    internal class BinaryOperatorParselet : InfixParselet
    {
        public Expression Parse(PrattParser parser, Expression left, LexerToken token)
        {
            var right = parser.ParseExpression();
            return new OperatorExpression(left, token.Type, right);
        }
    }
}
