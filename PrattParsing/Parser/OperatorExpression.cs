using PrattParsing.Lexer;

namespace PrattParsing.Parser
{
    public record OperatorExpression(Expression left, LexerTokenType @operator, Expression right) : Expression { };
    
}