namespace PrattParsing.Parser
{
    internal record NumberExpression(string Literal, int Value) : Expression { };
}
