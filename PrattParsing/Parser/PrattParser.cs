﻿using PrattParsing.Lexer;
using PrattParsing.Parser.Parselet;
using System.Net;
using static PrattParsing.Lexer.LexerTokenType;
namespace PrattParsing.Parser
{
    public class PrattParser
    {
        private List<LexerToken> _tokens;
        internal int _currentPosition;
        internal int _nextPosition;

        List<Expression> _Ast = new List<Expression>();

        private Dictionary<LexerTokenType, PrefixParselet> _prefixParselets = new()
        {
            { INT, new NumberParselet() },
            { LITERAL, new NameParselet() },
            { PLUS, new PrefixOperatorParselet() },
            { MINUS, new PrefixOperatorParselet() },
            { BANG, new PrefixOperatorParselet() },
            { TILDE, new PrefixOperatorParselet() },
        };
        private Dictionary<LexerTokenType, InfixParselet> _infixParselets = new()
        {
            { PLUS, new BinaryOperatorParselet() },
            { MINUS, new BinaryOperatorParselet() },
            { BANG, new BinaryOperatorParselet() },
            { TILDE, new BinaryOperatorParselet() },
        };

        public PrattParser(PrattLexer l)
        {
            _tokens = l.GetTokens().ToList();
        }

        public List<Expression> Parse()
        {
            while (!AtEnd())
            {
                this._Ast.Add(ParseExpression());
            }
            return _Ast;
        }

        public Expression ParseExpression()
        {
            LexerToken token = this.Consume();
            if (!this._prefixParselets.ContainsKey(token.Type)) throw new ParserException($"Cannot find token type in Parser: {token.Type}");
            var prefix = this._prefixParselets[token.Type];

            Expression left = prefix.Parse(this, token);

            // EffectivePeek
            token = LookAhead(0);
            InfixParselet? infix = GetInfixParslet(token.Type);

            // Expression completed no fix required.
            if (infix == null) return left;
            // Move next so we can get the right side of the infix expression
            Consume();
            return infix.Parse(this, left, token);
        }

        private InfixParselet? GetInfixParslet(LexerTokenType type)
        {
            InfixParselet? infixParslet;
            this._infixParselets.TryGetValue(type, out infixParslet);
            return infixParslet;
        }

        /// <summary>
        /// I think! I think we're peeking the Lexer here...I think.
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        private LexerToken LookAhead(int distance)
        {
            var peekToken = _currentPosition + distance;
            if (peekToken <= _tokens.Count)
                return _tokens[_currentPosition + distance];
            return new LexerToken(EOF, null);
        }

        private LexerToken Consume()
        {
            if (!AtEnd())
            {
                _currentPosition++;
                return Previous();
            }
            throw new ArgumentOutOfRangeException("Reached end of tokens");
        }


        private LexerToken Peek()
        {
            return _tokens[_currentPosition];
        }

        private bool AtEnd()
        {
            return Peek().Type == EOF;
        }

        private LexerToken Previous()
        {
            return _tokens[_currentPosition - 1];
        }

        /// <summary>
        /// MAtch the next token, and expect it to be the tagged token
        /// if not throw like a screaming toddler
        /// </summary>
        /// <param name="cOLON"></param>
        /// <exception cref="NotImplementedException"></exception>
        internal Token Consume(LexerTokenType expectedToken)
        {
            var token = this.LookAhead(0);
            if (token.Type != expectedToken)
                throw new ParserException($"Failed to consume : {expectedToken} got= {token.Type}");
            else
                return token;
        }
    }
}
