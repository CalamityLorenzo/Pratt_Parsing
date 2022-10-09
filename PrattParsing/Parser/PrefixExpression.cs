using PrattParsing.Lexer;

namespace PrattParsing.Parser
{
    public record PrefixExpression(LexerTokenType type, Expression operand) : Expression;
}