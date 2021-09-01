namespace BTTest.Server.Cards
{
    public record Suit
    {
        public enum SUIT { Clubs, Diamonds, Hearts, Spades}

        public SUIT Value { get; init; }

        public Suit(SUIT value) { Value = value; }

        public int GetMultiplier()
        {
            return Value switch
            {
                SUIT.Clubs => 1,
                SUIT.Diamonds => 2,
                SUIT.Hearts => 3,
                SUIT.Spades => 4,
                // Not reachable:
                _ => 1,
            };
        }

        public override string ToString()
        {
            return Value switch
            {
                SUIT.Clubs => "C",
                SUIT.Diamonds => "D",
                SUIT.Hearts => "H",
                SUIT.Spades => "S",
                // Not reachable:
                _ => string.Empty,
            };
        }

        public static ExecutionResult<Suit> Build(char c)
        {
            return c switch
            {
                'C' => ExecutionResult<Suit>.BuildPositive(new(SUIT.Clubs)),
                'D' => ExecutionResult<Suit>.BuildPositive(new(SUIT.Diamonds)),
                'H' => ExecutionResult<Suit>.BuildPositive(new(SUIT.Hearts)),
                'S' => ExecutionResult<Suit>.BuildPositive(new(SUIT.Spades)),
                _ => ExecutionResult<Suit>.BuildNegative("Input for suit is not correct"),
            };
        }
    }
}
