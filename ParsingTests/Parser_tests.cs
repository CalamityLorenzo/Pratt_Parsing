using PrattParsing.Lexer;
using PrattParsing.Parser;

namespace ParsingTests
{
    internal class ParserTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test(Description = "Does the Parse reach the end.")]
        public void ParseTillEnd()
        {
            var input = "Larry Harry";
            var l = new PrattLexer(input);

            PrattParser p = new(l);
            var result = p.Parse();
            Assert.IsTrue(result.Count>-1);
        }

        [Test(Description = "Only prefix parsing available")]
        public void OnlyPrefix()
        {
            // We want two expressions, both prefix.
            var input = "-5;+5";
            var l = new PrattLexer(input);

            PrattParser p = new(l);
            var result = p.Parse();

            var list = new List<Expression>
            {
                new PrefixExpression(LexerTokenType.MINUS, new NumberExpression("5", 5)),
                new PrefixExpression(LexerTokenType.PLUS, new NumberExpression("5", 5))
            };
            Assert.IsTrue(result.SequenceEqual(list));
        }


        [Test(Description = "Binary Operator")]
        public void BinaryOperatorParselet()
        {
            // We want two expressions, both prefix.
            var input = "5+7";
            var l = new PrattLexer(input);

            PrattParser p = new(l);
            var result = p.Parse();

            var list = new List<Expression>
            {
                new OperatorExpression(
                    new NumberExpression("5", 5), 
                        LexerTokenType.PLUS, 
                new NumberExpression("7", 7)),
            };
            Assert.IsTrue(result.SequenceEqual(list));
        }

        [Test(Description = "Binary Operator")]
        public void ConditionalOperator()
        {
            // We want two expressions, both prefix.
            var input = "8+2?3/1:8/2;";
            input = "a + (b ? c! : -d)";
            var l = new PrattLexer(input);

            PrattParser p = new(l);
            var result = p.Parse();

            var list = new List<Expression>
            {
                new OperatorExpression(
                    new NumberExpression("5", 5),
                        LexerTokenType.PLUS,
                new NumberExpression("7", 7)),
            };
            Assert.IsTrue(result.SequenceEqual(list));
        }
    }
}
