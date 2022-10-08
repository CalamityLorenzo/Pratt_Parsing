using PrattParsing.Lexer;

namespace PrattParsing.Parser
{
    internal record PrefixExpression(LexerTokenType type, Expression operand) : Expression;
}