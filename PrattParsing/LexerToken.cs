using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParsing
{
    public record LexerToken (LexerTokenType type, string literal);
}
