using BTTest.Server.Cards;

using Xunit;

namespace BTTest.Server.Tests.Cards
{
    public class SuitTests
    {
        [Theory]
        [InlineData('C', Suit.SUIT.Clubs)]
        [InlineData('D', Suit.SUIT.Diamonds)]
        [InlineData('H', Suit.SUIT.Hearts)]
        [InlineData('S', Suit.SUIT.Spades)]
        public void Build_Valid_Values(char c, Suit.SUIT expected)
        {
            Assert.Equal(expected, Suit.Build(c).Result.Value);
        }

        [Theory]
        [InlineData('c', "Input for suit is not correct")]
        [InlineData('4', "Input for suit is not correct")]
        [InlineData('*', "Input for suit is not correct")]
        public void Build_Invalid_Values(char c, string errorMessage)
        {
            Assert.Equal(errorMessage, Suit.Build(c).ErrorMessage);
        }

        [Theory]
        [InlineData('C', 1)]
        [InlineData('D', 2)]
        [InlineData('H', 3)]
        [InlineData('S', 4)]
        public void GetMultiplier_Results(char c, int multiplier)
        {
            Assert.Equal(multiplier, Suit.Build(c).Result.GetMultiplier());
        }

        [Theory]
        [InlineData('C', "C")]
        [InlineData('D', "D")]
        [InlineData('H', "H")]
        [InlineData('S', "S")]
        public void ToString_Results(char c, string output)
        {
            Assert.Equal(output, Suit.Build(c).Result.ToString());
        }
    }
}
