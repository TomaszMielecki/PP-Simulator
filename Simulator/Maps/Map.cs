using System.Drawing;

namespace Simulator.Maps
{

    /// <summary>
    /// Map of points.
    /// </summary>
    /// 
    public abstract class Map
    {
        // Add(IMappable, Point)

        // Remove(IMappable, Point)

        // Move()

        // At(Point) albo x, y x2


        private readonly Rectangle _map;

        protected readonly List<IMappable>?[,] _fields;
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }

        protected Map(int sizeX, int sizeY ) 
        {
            if (sizeX < 5 || sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Niestety rozmiar mapy musi wynosić przynajmniej 5.");
            }
            SizeX = sizeX;
            SizeY = sizeY;
            _map = new Rectangle(0,0, SizeX - 1, SizeY - 1);

            _fields = new List<IMappable>?[SizeX, SizeY];

        }
        

        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public virtual bool Exist(Point p) =>  _map.Contains(p);

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);

        public void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException("Position is out of map bounds.");

            if (_fields[position.X, position.Y] == null)
                _fields[position.X, position.Y] = new List<IMappable>();

            if (!_fields[position.X, position.Y].Contains(mappable))
                _fields[position.X, position.Y]!.Add(mappable);
        }



        public void Remove(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException("Position is out of map bounds.");

            if (_fields[position.X, position.Y]?.Contains(mappable) ?? false)
            {
                _fields[position.X, position.Y]?.Remove(mappable);

                if (_fields[position.X, position.Y]?.Count == 0)
                    _fields[position.X, position.Y] = null;
            }
        }

        public void Move(IMappable mappable, Point from, Point to)
        {
            if (!Exist(from) || !Exist(to)) throw new ArgumentException("One of the position is out of map");
            Remove(mappable, from);
            Add(mappable, to);
        }

        public List<IMappable>? At(Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException("Position is out of map bounds.");

            return _fields[position.X, position.Y];
        }

        public List<IMappable>? At(int x, int y)
        {
            if (x < 0 || x >= SizeX || y < 0 || y >= SizeY)
                throw new ArgumentOutOfRangeException("Coordinates are out of map bounds.");
            return _fields[x, y];
        }
    }
}