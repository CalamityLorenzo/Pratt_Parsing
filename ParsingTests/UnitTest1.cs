namespace ParsingTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test(Description ="Does the lexer run")]
        public void Test1()
        {
            var input = "5+5";
            var l = new PrattLexer(input);

            IEnumerable<Tokens> lTokens = l.GetTokens();
            Assert.IsTrue(true);
        }
    }
}