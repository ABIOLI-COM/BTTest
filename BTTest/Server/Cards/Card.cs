namespace BTTest.Server.Cards
{
    // Given the exercise, and the fact that the deck is really improbable to change, there is a much simpler solution
    // creating a set of constant cards, and just referring them, but the code would be really too simple.
    // Let's write an 'articulated' solution.

    public record Card
    {
        public Suit Suit { get; init; }
        public FaceValue FaceValue { get; init; }
        public SpecialCard SpecialCard { get; init; }

        public Card(Suit suit, FaceValue faceValue) { Suit = suit; FaceValue = faceValue; SpecialCard = new(SpecialCard.SPECIALCARD.None); }
        public Card(SpecialCard specialCard) { Suit = default; FaceValue = default; SpecialCard = specialCard; }

        public bool IsSpecialCard() => SpecialCard.Value != SpecialCard.SPECIALCARD.None;

        public int CalculateValue()
        {
            if (IsSpecialCard())
            {
                return 0; // We want values only for 'normal' cards (at least for the moment)
            }

            return Suit.GetMultiplier() * FaceValue.GetCardValue();
        }

        public override string ToString()
        {
            if (IsSpecialCard())
            {
                return SpecialCard.ToString();
            }

            return FaceValue.ToString() + Suit.ToString();
        }
        
        public static ExecutionResult<Card> Build(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length != 2)
                return ExecutionResult<Card>.BuildNegative("Invalid input string");

            // Special card(s)
            if (s == "JR")
            {
                return ExecutionResult<Card>.BuildPositive(new Card(new SpecialCard(SpecialCard.SPECIALCARD.Joker)));
            }
            
            ExecutionResult<Suit> suiteRes = Suit.Build(s[1]);

            if (suiteRes.IsError())
            {
                return ExecutionResult<Card>.BuildNegative("Card not recognised");
            }

            ExecutionResult<FaceValue> faceValueRes = FaceValue.Build(s[0]);

            if (faceValueRes.IsError())
            {
                return ExecutionResult<Card>.BuildNegative("Card not recognised");
            }

            return ExecutionResult<Card>.BuildPositive(new Card(suiteRes.Result, faceValueRes.Result));
        }
    }
}
