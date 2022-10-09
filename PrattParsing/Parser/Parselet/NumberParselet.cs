using PrattParsing.Lexer;

namespace PrattParsing.Parser.Parselet
{
    internal class NumberParselet : PrefixParselet
    {
        public Expression Parse(PrattParser parser, LexerToken token)
        {
            return new NumberExpression(token.Literal, int.Parse(token.Literal));
        }
    }
}
