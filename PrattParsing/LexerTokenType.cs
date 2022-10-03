namespace PrattParsing
{
    public enum LexerTokenType
    {
        PLUS,
        PLUS_PLUS,
        MINUS,
        MINUS_MINUS,
        ASTERISK,
        SLASH,
        BANG,
        BANG_EQUALS,
        AMPERSAND,
        LEFT_PARENS,
        RIGHT_PARENS,
        LEFT_BRACE,
        RIGHT_BRACE,

        EQUALS,
        ASSIGN,

        QUESTION_MARK,
        COLON,
        SEMI_COLON,
        INT,
        LITERAL,

        EOF
    }
}