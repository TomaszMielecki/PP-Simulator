namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
    }

    public override Point Next(Point p, Direction d)
    {

        Point examplePoint = p.Next(d);

        return Exist(examplePoint) ? examplePoint : p;

    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point examplePoint = p.NextDiagonal(d);

        return Exist(examplePoint) ? examplePoint : p;
    }

}