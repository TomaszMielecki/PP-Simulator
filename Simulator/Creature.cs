using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public abstract class Creature : IMappable
    {

        public Map? Map { get; private set; }

        public Point? Position { get; private set; }

        public abstract char Symbol { get; }

        private string _name = "Unkown";

        private int _level = 1;

        public string Name
        {
            get => _name;
            init
            {
                _name = Validator.Shortener(value, 3, 25, '#');
            }

        }
        public int Level
        {
            get => _level;
            init 
            {
                _level = Validator.Limiter(value, 1, 10);
            }
        }
        public Creature()
        {
        }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public abstract string Info { get; }
        public abstract int Power { get; }
        public abstract string Greeting();
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }

        public void InitMapAndPosition(Map map, Point position)
        {
            if (Map != null)
                throw new InvalidOperationException("Ten stwór jest już przypisany do mapy.");

            if (map == null)
                throw new ArgumentNullException("Mapa nie może być null.");

            if (!map.Exist(position))
                throw new ArgumentException("Ta pozycja nie jest prawidłowa na tej mapie.", nameof(position));


            Map = map;
            Position = position;

            map.Add(this, position);
        }

        public void Upgrade()
        {
            if (_level < 10)
            {
                _level++;
            }
        }

        public void Go(Direction direction)
        {
            if (Map == null)
            {
                throw new InvalidOperationException("Stwór nie jest przypisany do żadnej mapy.");
            }
            Point newPosition = Map.Next(Position, direction);

            if (!Map.Exist(newPosition))
            {
                throw new InvalidOperationException("Nowa pozycja nie znajduje się w granicach mapy");
            }

            var creaturesAtNewPosition = Map.At(newPosition);

            if (creaturesAtNewPosition != null && creaturesAtNewPosition.Count > 0)
            {
                throw new InvalidOperationException("Nowa pozycja jest zajęta przez inne stwory.");
            }
            

            Map.Move(this, Position, newPosition);
            Position = newPosition;
            //return $"{Name} goes {direction.ToString().ToLower()}.";
        }
    }
}
