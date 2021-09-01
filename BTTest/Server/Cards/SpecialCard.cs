namespace BTTest.Server.Cards
{
    public record SpecialCard
    {
        public enum SPECIALCARD { None, Joker }

        public SPECIALCARD Value { get; init; }

        public SpecialCard(SPECIALCARD value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value switch
            {
                SPECIALCARD.None => string.Empty,// Never used
                SPECIALCARD.Joker => "JR",
                // Not reacheable
                _ => string.Empty,
            };
        }
    }
}
