namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        Point newPoint = p.Next(d);

        int newX = (newPoint.X % SizeX + SizeX) % SizeX;
        int newY = (newPoint.Y % SizeY + SizeY) % SizeY;

        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point newDiagonalPoint = p.NextDiagonal(d);

        int newX = (newDiagonalPoint.X % SizeX + SizeX) % SizeX;
        int newY = (newDiagonalPoint.Y % SizeY + SizeY) % SizeY;

        return new Point(newX, newY);
    }

}