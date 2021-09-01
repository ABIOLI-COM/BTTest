using BTTest.Server.Cards;

using Xunit;

namespace BTTest.Server.Tests.Cards
{
    public class HandTests
    {
        [Theory]
        // Basic
        [InlineData("2C", 2)]
        [InlineData("2D", 4)]
        [InlineData("2H", 6)]
        [InlineData("2S", 8)]
        [InlineData("TC", 10)]
        [InlineData("JC", 11)]
        [InlineData("QC", 12)]
        [InlineData("KC", 13)]
        [InlineData("AC", 14)]
        [InlineData("3C,4C", 7)]
        // Jokers
        [InlineData("JR", 0)]
        [InlineData("JR,JR", 0)]
        [InlineData("2C,JR", 4)]
        [InlineData("JR,2C,JR", 8)]
        [InlineData("TC,TD,JR,TH,TS", 200)]
        [InlineData("TC,TD,JR,TH,TS,JR", 400)]
        public void Scenario1_Valid_Tests(string cardsRep, int handValue)
        {
            Assert.Equal(handValue, Hand.Build(cardsRep).Result.GetValue());
        }


        [Theory]
        [InlineData("1S", "Card not recognised")]
        [InlineData("2B", "Card not recognised")]
        [InlineData("2S,1S", "Card not recognised")]
        [InlineData("3H,3H", "Cards cannot be duplicated")]
        [InlineData("4D,5D,4D", "Cards cannot be duplicated")]
        [InlineData("JR,JR,JR", "A hand cannot contain more than two Jokers")]
        [InlineData("2S|3D", "Invalid input string")]
        public void Scenario2_Invalid_Tests(string cardsRep, string errorMessage)
        {
            Assert.Equal(errorMessage, Hand.Build(cardsRep).ErrorMessage);
        }
    }
}
