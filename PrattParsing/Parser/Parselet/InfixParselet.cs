using PrattParsing.Lexer;

namespace PrattParsing.Parser.Parselet
{
    /// <summary>
    /// For a+b scenarios. We have an expression (left), and the next/this ast-token is a known operator or somekind
    /// </summary>
    interface InfixParselet
    {
        Expression Parse(PrattParser parser, Expression left, LexerToken token);
    }
}
