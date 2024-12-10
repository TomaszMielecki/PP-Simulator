using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    public uint Size { get; set; } = 3;
    public Map? Map { get; private set; }
    public Point Position { get; protected set; }

    public virtual char Symbol => 'A';


    public required string Description
    {
        get => _description;

        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _description = "###";
            }
            else
            {
                _description = Validator.Shortener(value, 3, 15, '#');
            }

            if (_description.Length > 0 && char.IsLower(_description[0]))
            {
                _description = char.ToUpper(_description[0]) + _description.Substring(1);
            }
        }
    }

    public virtual string Info => $"{Description} <{Size}>";

    public virtual void Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("Animal cannot move since it's not on the map!");
        var newPosition = GetNewPosition(direction);

        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }

    public virtual void InitMapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        
        if (!map.Exist(point)) throw new ArgumentException("Non-existing position for this map.");
        Map = map;
        Position = point;
        map.Add(this, point);
    }

    protected virtual Point GetNewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}