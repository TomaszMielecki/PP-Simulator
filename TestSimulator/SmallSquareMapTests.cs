using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;

        // Act
        var map = new SmallSquareMap(size);

        // Assert
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(0, 0, 12, true)]
    [InlineData(11, 11, 12, true)]
    [InlineData(12, 12, 12, false)]
    [InlineData(-1, -1, 12, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);

        // Act
        var result = map.Exist(point);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(7, 7, Direction.Up, 7, 8)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(11, 11, Direction.Right, 11, 11)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(12);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.Next(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(7, 7, Direction.Up, 8, 8)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(11, 11, Direction.Right, 11, 11)]
    [InlineData(1, 1, Direction.Down, 0, 0)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(12);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.NextDiagonal(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}