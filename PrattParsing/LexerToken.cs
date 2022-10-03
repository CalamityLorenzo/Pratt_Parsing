using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParsing
{
    internal record LexerToken (LexerTokenType type, string literal);
}
