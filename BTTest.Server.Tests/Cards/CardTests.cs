using BTTest.Server.Cards;

using Microsoft.AspNetCore.Localization;

using Xunit;

namespace BTTest.Server.Tests.Cards
{
    public class CardTests
    {
        [Theory]
        [InlineData("JR", "JR")]
        [InlineData("2S", "2S")]
        [InlineData("4D", "4D")]
        [InlineData("JC", "JC")]
        [InlineData("AH", "AH")]
        public void Build_Valid_Values(string cardRep, string toStringRep)
        {
            Assert.Equal(toStringRep, Card.Build(cardRep).Result.ToString());
        }

        [Theory]
        [InlineData("*", "Invalid input string")]
        [InlineData("***", "Invalid input string")]
        [InlineData("**", "Card not recognised")]
        [InlineData("4s", "Card not recognised")]
        [InlineData("1C", "Card not recognised")]
        public void Build_Invalid_Values(string cardRep, string errorMessage)
        {
            Assert.Equal(errorMessage, Card.Build(cardRep).ErrorMessage);
        }

        [Theory]
        [InlineData("2C", 2)]
        [InlineData("2D", 4)]
        [InlineData("2H", 6)]
        [InlineData("2S", 8)]
        [InlineData("TC", 10)]
        [InlineData("JC", 11)]
        [InlineData("QC", 12)]
        [InlineData("KC", 13)]
        [InlineData("AC", 14)]
        [InlineData("JR", 0)]
        public void CalculateValue_Results(string cardRep, int expected)
        {
            Assert.Equal(expected, Card.Build(cardRep).Result.CalculateValue());
        }
    }
}
