using PrattParsing;
using System.Reflection;

namespace ParsingTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test(Description = "Does the lexer run")]
        public void WeHaveTokens()
        {
            var input = "5 + 5";
            var l = new PrattLexer(input);

            IEnumerable<LexerToken> lTokens = l.GetTokens();
            Assert.IsTrue(lTokens.Count() == 3);
        }


        [Test(Description = "Ignores the rubbish space")]
        public void IgnoreWhiteSpaceAndnewLines()
        {
            var input = "5 +\n 5\r\n;";
            var l = new PrattLexer(input);

            IEnumerable<LexerToken> lTokens = l.GetTokens();
            Assert.IsTrue(lTokens.Count() == 4);
        }

        [Test(Description = "Ignores the rubbish space")]
        public void ValidateTokens()
        {
            var input = "5%5=(10);";

            var l = new PrattLexer(input);
            var lt = l.GetTokens().ToList();

            var result = new List<LexerToken> {
                new (LexerTokenType.INT, "5"),
                new (LexerTokenType.MOD, "%"),
                new (LexerTokenType.INT, "5"),
                new (LexerTokenType.ASSIGN, "="),
                new (LexerTokenType.LEFT_BRACE, "("),
                new (LexerTokenType.INT, "10"),
                new (LexerTokenType.RIGHT_BRACE, ")"),
                new (LexerTokenType.SEMI_COLON, ";"),
            };

            Assert.True(result.SequenceEqual(lt));

        }
    }
}