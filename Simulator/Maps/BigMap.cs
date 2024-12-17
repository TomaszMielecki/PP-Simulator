namespace Simulator.Maps;

public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _fields;

    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide. Max width is 1000.");

        if (sizeY > 1000)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high. Max hight is 1000.");

        _fields = new Dictionary<Point, List<IMappable>>();
    }

    

}
