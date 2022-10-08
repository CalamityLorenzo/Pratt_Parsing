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
    }
}
