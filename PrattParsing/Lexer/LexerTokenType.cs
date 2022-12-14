namespace PrattParsing.Lexer
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
        MOD,

        LEFT_PARENS,
        RIGHT_PARENS,
        LEFT_BRACE,
        RIGHT_BRACE,

        EQUALS,
        ASSIGN,
        TILDE,
        CARET,

        QUESTION_MARK,
        COLON,
        SEMI_COLON,
        INT,
        LITERAL,
        COMMENT,
        EOF
    }
}