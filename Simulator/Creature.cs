using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public virtual char Symbol => 'C';

    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init
        {

            if (value == null)
            {
                _name = "###";
            }
            else
            {
                _name = Validator.Shortener(value.Trim(), 3, 25, '#');
                if (_name.Length > 0 && char.IsLower(_name[0]))
                {
                    _name = char.ToUpper(_name[0]) + _name.Substring(1);
                }
            }
        }
    }


    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }


    public Creature(string name, int level = 1) : this()
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public string Greeting { get; }

    public abstract string Info { get; }

    public void InitMapAndPosition(Map map, Point position)
    {
        

        if (map == null)
            throw new ArgumentNullException("Mapa nie może być null.");

        if (!map.Exist(position))
            throw new ArgumentException("Ta pozycja nie jest prawidłowa na tej mapie.", nameof(position));


        Map = map;
        Position = position;

        map.Add(this, position);
    }

    public void Go(Direction direction)
    {
        if (Map == null)
            throw new InvalidOperationException("Stworzenie nie jest przypisane do żadnej mapy.");

        Point newPosition = Map.Next(Position, direction);

        if (!Map.Exist(newPosition))
            throw new InvalidOperationException("Nowa pozycja jest poza granicami mapy.");

        // Sprawdzamy, czy nowa pozycja jest zajęta
        var creaturesAtNewPosition = Map.At(newPosition);
        if (creaturesAtNewPosition != null && creaturesAtNewPosition.Count > 0)
            throw new InvalidOperationException("Nowa pozycja jest zajęta przez inne stworzenia.");

        // Przemieszczamy stworzenie
        Map.Move(this, Position, newPosition);
        Position = newPosition;

    }

    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}