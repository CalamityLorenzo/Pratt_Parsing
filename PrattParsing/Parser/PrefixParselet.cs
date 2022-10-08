using PrattParsing.Lexer;

namespace PrattParsing.Parser
{
    public interface  PrefixParselet
    {
        Expression Parse(PrattParser parser, LexerToken token);
    }

    public record NameParselet : PrefixParselet
    {
        public Expression Parse(PrattParser parser, LexerToken token)
        {
            return new NameExpression(token.literal);
        }
    }
}
