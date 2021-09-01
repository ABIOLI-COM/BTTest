using BTTest.Server.Cards;

using Xunit;

namespace BTTest.Server.Tests.Cards
{
    public class FaceValueTests
    {
        [Theory]
        [InlineData('2', FaceValue.FACEVALUE.Two)]
        [InlineData('3', FaceValue.FACEVALUE.Three)]
        [InlineData('4', FaceValue.FACEVALUE.Four)]
        [InlineData('5', FaceValue.FACEVALUE.Five)]
        [InlineData('6', FaceValue.FACEVALUE.Six)]
        [InlineData('7', FaceValue.FACEVALUE.Seven)]
        [InlineData('8', FaceValue.FACEVALUE.Eight)]
        [InlineData('9', FaceValue.FACEVALUE.Nine)]
        [InlineData('T', FaceValue.FACEVALUE.Ten)]
        [InlineData('J', FaceValue.FACEVALUE.Jack)]
        [InlineData('Q', FaceValue.FACEVALUE.Queen)]
        [InlineData('K', FaceValue.FACEVALUE.King)]
        [InlineData('A', FaceValue.FACEVALUE.Ace)]
        public void Build_Valid_Values(char c, FaceValue.FACEVALUE expected)
        {
            Assert.Equal(expected, FaceValue.Build(c).Result.Value);
        }

        [Theory]
        [InlineData('t', "Input for face value is not correct")]
        [InlineData('1', "Input for face value is not correct")]
        [InlineData('*', "Input for face value is not correct")]
        public void Build_Invalid_Values(char c, string errorMessage)
        {
            Assert.Equal(errorMessage, FaceValue.Build(c).ErrorMessage);
        }

        [Theory]
        [InlineData('2', 2)]
        [InlineData('3', 3)]
        [InlineData('4', 4)]
        [InlineData('5', 5)]
        [InlineData('6', 6)]
        [InlineData('7', 7)]
        [InlineData('8', 8)]
        [InlineData('9', 9)]
        [InlineData('T', 10)]
        [InlineData('J', 11)]
        [InlineData('Q', 12)]
        [InlineData('K', 13)]
        [InlineData('A', 14)]
        public void GetCardValue_Results(char c, int multiplier)
        {
            Assert.Equal(multiplier, FaceValue.Build(c).Result.GetCardValue());
        }

        [Theory]
        [InlineData('2', "2")]
        [InlineData('3', "3")]
        [InlineData('4', "4")]
        [InlineData('5', "5")]
        [InlineData('6', "6")]
        [InlineData('7', "7")]
        [InlineData('8', "8")]
        [InlineData('9', "9")]
        [InlineData('T', "T")]
        [InlineData('J', "J")]
        [InlineData('Q', "Q")]
        [InlineData('K', "K")]
        [InlineData('A', "A")]
        public void ToString_Results(char c, string output)
        {
            Assert.Equal(output, FaceValue.Build(c).Result.ToString());
        }
    }
}
