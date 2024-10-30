using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    internal class Creature
    {
        private string _name = "Unkown";

        private int _level = 1;

        public string Name
        {
            get => name;
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
    }
}
