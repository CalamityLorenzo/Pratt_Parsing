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
                new (LexerTokenType.LEFT_PARENS, "("),
                new (LexerTokenType.INT, "10"),
                new (LexerTokenType.RIGHT_PARENS, ")"),
                new (LexerTokenType.SEMI_COLON, ";"),
            };

            Assert.True(result.SequenceEqual(lt));

        }

        [Test(Description = "Are we collecting the multi-length tokens eg -- ++ ")]
        public void MultiCharTokens()
        {
            var input = "++5/8==(--10);";

            var l = new PrattLexer(input);
            var lt = l.GetTokens().ToList();


            var result = new List<LexerToken> {
                new (LexerTokenType.PLUS_PLUS, "++"),
                new (LexerTokenType.INT, "5"),
                new (LexerTokenType.SLASH, "/"),
                new (LexerTokenType.INT, "8"),
                new (LexerTokenType.EQUALS, "=="),
                new (LexerTokenType.LEFT_PARENS, "("),
                new (LexerTokenType.MINUS_MINUS, "--"),
                new (LexerTokenType.INT, "10"),
                new (LexerTokenType.RIGHT_PARENS, ")"),
                new (LexerTokenType.SEMI_COLON, ";"),
            };

            Assert.True(lt.SequenceEqual(result));

        }
    }
}