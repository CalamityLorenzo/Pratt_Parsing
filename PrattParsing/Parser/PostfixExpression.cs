using PrattParsing.Lexer;

namespace PrattParsing.Parser
{
    internal record PostfixExpression(Expression Left, LexerTokenType Type) : Expression
}
