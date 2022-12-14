using PrattParsing.Lexer;
using static PrattParsing.Lexer.LexerTokenType;

namespace PrattParsing.Parser.Parselet
{
    internal record ConditionalParselet : InfixParselet
    {
        private int _precedence;

        public ConditionalParselet(int precedence) => this._precedence = precedence;

        public int GetPrecedence() => this._precedence;
        public Expression Parse(PrattParser parser, Expression left, LexerToken token)
        {
            Expression thenArm = parser.ParseExpression();
            // Consume and then discard,.
            parser.Consume(COLON);

            Expression elseArm = parser.ParseExpression();

            return new ConditionalExpression(left, thenArm, elseArm);
        }
    }
}
