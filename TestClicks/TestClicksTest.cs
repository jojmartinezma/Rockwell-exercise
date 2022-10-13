using Xunit;

using Find_clicks;

namespace TestClicks
{
    public class TestClicksTest
    {
       private Clicks clickFunction = new Clicks();

        [Fact]
        public void GetClicksForJoseTextAndReturn15()
        {
            // arrange
            int expectedClicksNumber = 15;
            string text = "jose";

            // act
            int clicksResult = clickFunction.ClicksCount(text.ToLower());

            // assert
            Assert.True(clicksResult == expectedClicksNumber);
        }

        [Theory]
        [InlineData("ant",10)]
        [InlineData("ANT",10)]
        [InlineData("jose",15)]
        [InlineData("joseñ",15)]
        [InlineData("house",24)]
        [InlineData("ho11us22e3",24)]
        [InlineData("Rockwell", 33)]
        [InlineData("**Roc*kwell//", 33)]
        public void GetClicksForString(string text, int expectedClicksNumber)
        {
            // arrange -> in the theory

            // act
            int clicksResult = clickFunction.ClicksCount(text.ToLower());

            // assert
            Assert.Equal(expectedClicksNumber, clicksResult);
        }
    }
}