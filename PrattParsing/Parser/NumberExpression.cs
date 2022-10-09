namespace PrattParsing.Parser
{
    public record NumberExpression(string Literal, int Value) : Expression { };
}
