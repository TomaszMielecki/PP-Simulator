namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public Direction Bounce(Direction d)
    {
        return d switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => d
        };
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        if (Exist(nextPoint))
        {
            return nextPoint;
        }
        else
        {
            return p.Next(Bounce(d));
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        if (Exist(nextPoint))
        {
            return nextPoint;
        }
        else
        {
            return p.NextDiagonal(Bounce(d));
        }
    }

}