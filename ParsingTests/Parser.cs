using PrattParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var input = "5 + 5";
            var l = new PrattLexer(input);

            PrattParser p = new(l);
            var result = p.Parse();
            Assert.IsTrue(result.Count>-1);
        }
    }
}
