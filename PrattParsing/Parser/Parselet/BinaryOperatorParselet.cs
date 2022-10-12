using PrattParsing.Lexer;
using System.Security.AccessControl;

namespace PrattParsing.Parser.Parselet
{
    internal class BinaryOperatorParselet : InfixParselet
    {
        private int _precedence;
        private readonly bool isRightAssoc;

        public BinaryOperatorParselet(int precedence, Boolean isRightAssoc)
        {
            _precedence = precedence;
            this.isRightAssoc = isRightAssoc;
        }

        public int GetPrecedence() => this._precedence;

        public Expression Parse(PrattParser parser, Expression left, LexerToken token)
        {
            var right = parser.ParseExpression(_precedence - (isRightAssoc ? 1 : 0));
            return new OperatorExpression(left, token.Type, right);
        }
    }
}
