namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; private set; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Niestety rozmiar mapy musi mieścić się w przedziale pomiędzy 5, a 20.");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return (p.X >= 0 && p.X < Size) && (p.Y >= 0 && p.Y < Size);
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