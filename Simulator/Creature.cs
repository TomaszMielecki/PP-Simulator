using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public abstract class Creature
    {
        private string _name = "Unkown";

        private int _level = 1;

        public string Name
        {
            get => _name;
            init
            {
                string trimname = value.Trim();
                if (trimname.Length < 3)
                {
                    trimname = trimname.PadRight(3, '#');
                }
                if (trimname.Length > 25)
                {
                    trimname = trimname.Substring(0, 25).TrimEnd();
                    if (trimname.Length < 3)
                    {
                        trimname = trimname.PadRight(3, '#');
                    }
                }
                if (char.IsLower(trimname[0]))
                {
                    trimname = char.ToUpper(trimname[0]) + trimname.Substring(1);
                }

                _name = trimname;
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
        public abstract void SayHi();
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
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
            string lowerdirection = direction.ToString().ToLower();
            Console.WriteLine($"{Name} goes {lowerdirection}.");
        }

        public void Go(Direction[] directions)
        {
            foreach (Direction direction in directions)
            {
                Go(direction);
            }
        }

        public void Go(string directions)
        {
            var directionArray = DirectionParser.Parse(directions);
            Go(directionArray);
        }
    }
}
