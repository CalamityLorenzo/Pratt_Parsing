using PrattParsing.Lexer;

namespace PrattParsing.Parser.Parselet
{
    /// <summary>
    /// operator first eg -5, --8
    /// </summary>
    public interface PrefixParselet
    {
        Expression Parse(PrattParser parser, LexerToken token);
    }
}
