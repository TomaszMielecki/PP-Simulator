using Simulator;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 1, 10, 5)]
        [InlineData(0, 1, 10, 1)]
        [InlineData(1, 1, 10, 1)]
        [InlineData(10, 1, 10, 10)]
        public void Limiter_ShouldReturnExpectedResult(int value, int min, int max, int expected)
        {
            // Act
            var result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hell", 5, 10, '*', "Hell*")]
        [InlineData("hello", 5, 10, '*', "Hello")]
        [InlineData("helloworldeee", 5, 10, '*', "Helloworld")]
        public void Shortener_ShouldReturnCorrectResult(string value, int min, int max, char placeholder, string expected)
        {
            // Act
            var result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }
    }

}