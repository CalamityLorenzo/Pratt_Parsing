using PrattParsing.Lexer;

namespace PrattParsing.Parser.Parselet
{
    public record NameParselet : PrefixParselet
    {
        public Expression Parse(PrattParser parser, LexerToken token)
        {
            return new NameExpression(token.Literal);
        }
    }
}
