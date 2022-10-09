using PrattParsing.Lexer;

namespace PrattParsing.Parser.Parselet
{
    internal record PrefixOperatorParselet : PrefixParselet
    {
        public Expression Parse(PrattParser parser, LexerToken token)
        {
            // the sound of the machinery moving one step along
            Expression operand = parser.ParseExpression();
            return new PrefixExpression(token.Type, operand);
        }
    }
}
