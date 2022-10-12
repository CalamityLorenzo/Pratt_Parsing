using PrattParsing.Lexer;
using static PrattParsing.Lexer.LexerTokenType;
namespace PrattParsing.Parser.Parselet
{
    public record GroupParselet() : PrefixParselet
    {
        public Expression Parse(PrattParser parser, LexerToken token)
        {
            var exp = parser.ParseExpression();
            parser.Consume(RIGHT_PARENS);
            return exp;
        }
    }
}
