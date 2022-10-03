namespace PrattParsing
{
    internal class PrattLexer
    {
        private int currentPosition;
        private int NextPosition;
        private readonly string rawInput;

        public PrattLexer(string input)
        {
            this.currentPosition = 0;
            this.NextPosition = 1;
            this.rawInput = input!;
        }
        s
        public void MoveNextPosition()
        {
            this.currentPosition = NextPosition;
            if (NextPosition + 1 < rawInput.Length)
                NextPosition += 1;
        }
    }
}
