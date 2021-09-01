namespace BTTest.Server.Cards
{
    public record FaceValue
    {
        public enum FACEVALUE { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

        public FACEVALUE Value { get; init; }

        public FaceValue(FACEVALUE value) { Value = value; }

        public static ExecutionResult<FaceValue> Build(char c)
        {
            return c switch
            {
                '2' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Two)),
                '3' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Three)),
                '4' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Four)),
                '5' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Five)),
                '6' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Six)),
                '7' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Seven)),
                '8' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Eight)),
                '9' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Nine)),
                'T' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Ten)),
                'J' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Jack)),
                'Q' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Queen)),
                'K' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.King)),
                'A' => ExecutionResult<FaceValue>.BuildPositive(new(FACEVALUE.Ace)),
                _ => ExecutionResult<FaceValue>.BuildNegative("Input for face value is not correct"),
            };
        }

        public int GetCardValue()
        {
            return Value switch
            {
                FACEVALUE.Two => 2,
                FACEVALUE.Three => 3,
                FACEVALUE.Four => 4,
                FACEVALUE.Five => 5,
                FACEVALUE.Six => 6,
                FACEVALUE.Seven => 7,
                FACEVALUE.Eight => 8,
                FACEVALUE.Nine => 9,
                FACEVALUE.Ten => 10,
                FACEVALUE.Jack => 11,
                FACEVALUE.Queen => 12,
                FACEVALUE.King => 13,
                FACEVALUE.Ace => 14,
                // Not reachable:
                _ => 0,
            };
        }

        public override string ToString()
        {
            return Value switch
            {
                FACEVALUE.Two => "2",
                FACEVALUE.Three => "3",
                FACEVALUE.Four => "4",
                FACEVALUE.Five => "5",
                FACEVALUE.Six => "6",
                FACEVALUE.Seven => "7",
                FACEVALUE.Eight => "8",
                FACEVALUE.Nine => "9",
                FACEVALUE.Ten => "T",
                FACEVALUE.Jack => "J",
                FACEVALUE.Queen => "Q",
                FACEVALUE.King => "K",
                FACEVALUE.Ace => "A",
                // Not reachable:
                _ => string.Empty,
            };
        }

    }
}
