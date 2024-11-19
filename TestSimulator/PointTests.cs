using Simulator;

namespace TestSimulator
{
    public class PointTests
    {
        [Fact]
        public void Constructor_ShouldInitializePointCorrectly()
        {
            // Arrange & Act
            var point = new Point(5, 6);

            // Assert
            Assert.Equal(5, point.X);
            Assert.Equal(6, point.Y);
        }

        [Theory]
        [InlineData(5, 6, Direction.Up, 5, 7)]
        [InlineData(5, 6, Direction.Down, 5, 5)]
        [InlineData(5, 6, Direction.Left, 4, 6)]
        [InlineData(3, 4, Direction.Right, 4, 4)]
        public void Next_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var nextPoint = point.Next(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }

        [Theory]
        [InlineData(6, 6, Direction.Up, 7, 7)]
        [InlineData(6, 6, Direction.Down, 5, 5)]
        [InlineData(6, 6, Direction.Left, 5, 7)]
        [InlineData(6, 6, Direction.Right, 7, 5)]
        [InlineData(0, 0, Direction.Up, 1, 1)]
        [InlineData(0, 0, Direction.Down, -1, -1)]
        public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }
    }

}