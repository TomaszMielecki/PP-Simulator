using Simulator;
namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldCreateRectangle_FromPoints()
    {
        // Arrange
        var p1 = new Point(2, 2);
        var p2 = new Point(6, 6);

        // Act
        var rect = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(2, rect.X1);
        Assert.Equal(2, rect.Y1);
        Assert.Equal(6, rect.X2);
        Assert.Equal(6, rect.Y2);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        // Arrange
        var rect = new Rectangle(2, 2, 6, 6);

        // Act
        var result = rect.ToString();

        // Assert
        Assert.Equal("(2, 2):(6, 6)", result);
    }

    [Fact]
    public void Constructor_InvalidCoordinates_ShouldThrowException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(2, 2, 2, 6));
    }

    [Theory]
    [InlineData(3, 4, true)]
    [InlineData(6, 8, false)]
    public void Contains_ShouldReturnCorrectValue(int x, int y, bool expected)
    {
        // Arrange
        var rectangle = new Rectangle(2, 3, 5, 7);

        // Act
        var result = rectangle.Contains(new Point(x, y));

        // Assert
        Assert.Equal(expected, result);
    }
}

