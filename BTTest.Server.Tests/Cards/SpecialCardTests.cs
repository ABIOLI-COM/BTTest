using BTTest.Server.Cards;

using Xunit;

namespace BTTest.Server.Tests.Cards
{
    public class SpecialCardTests
    {
        [Theory]
        [InlineData(SpecialCard.SPECIALCARD.Joker, "JR")]
        [InlineData(SpecialCard.SPECIALCARD.None, "")]
        public void ToString_Values(SpecialCard.SPECIALCARD special, string expected)
        {
            Assert.Equal(expected, new SpecialCard(special).ToString());
        }
    }
}
