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

    public override void Add(IMappable mappable, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException("Position is out of map bounds.");

        if (!_fields.ContainsKey(position))
        {
            _fields[position] = new List<IMappable>();
        }
        _fields[position].Add(mappable);

    }

    public override void Remove(IMappable mappable, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException("Position is out of map bounds.");

        if (_fields.ContainsKey(position))
        {
            _fields[position].Remove(mappable);

            if (_fields[position].Count == 0)
            {
                _fields.Remove(position);
            }
        }
    }

    public override List<IMappable>? At(Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException("Position is out of map bounds.");

        return _fields.ContainsKey(position) ? _fields[position] : null;
    }

    public override List<IMappable>? At(int x, int y)
    {
        return At(new Point(x, y));
    }

}
