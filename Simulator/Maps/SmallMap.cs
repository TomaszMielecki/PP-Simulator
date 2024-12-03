namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {

        List<IMappable>? [,] _fields;

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (SizeX > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Niestety szerokość mapy może wynosić co najwyżej 20.");
            }
            if (SizeY > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Niestety wysokość mapy może wynosić co najwyżej 20.");
            }

            _fields = new List<IMappable>?[sizeX, sizeY];
        }

        public override void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException("Pozycja jest poza granicami mapy.");

            if (_fields[position.X, position.Y] == null)
                _fields[position.X, position.Y] = new List<IMappable>();

            _fields[position.X, position.Y]!.Add(mappable); // stwór dodany
        }

        public override void Remove(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Pozycja poza mapą.");

            _fields[position.X, position.Y]?.Remove(mappable);
            if (_fields[position.X, position.Y]?.Count == 0)
                _fields[position.X, position.Y] = null;       // stwór usunięty
        }

        public override List<IMappable>? At(Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException("Pozycja jest poza granicami mapy.");

            return _fields[position.X, position.Y];
        }

        public override List<IMappable>? At(int x, int y)
        {
            return At(new Point(x, y));
        }
    }
}
