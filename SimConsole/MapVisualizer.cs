﻿using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole
{
    public class MapVisualizer
    {
        private readonly Map _map;

        public MapVisualizer(Map map)
        {
            _map = map;
        }

        public void Draw()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write(Box.TopLeft);
            for (int x = 0; x < _map.SizeX; x++)
            {
                Console.Write(Box.Horizontal);
            }
            Console.WriteLine(Box.TopRight);

            for (int y = 0; y < _map.SizeY; y++)
            {
                Console.Write(Box.Vertical);

                for (int x = 0; x < _map.SizeX; x++)
                {
                    var creaturesAtPosition = _map.At(x, y);

                    //wyjątek na null, dopytaj na zajęciach

                    if (creaturesAtPosition.Count > 1)
                    {
                        Console.Write("X");
                    }
                    else if (creaturesAtPosition.Count == 1)
                    {
                        var creature = creaturesAtPosition[0];

                        if (creature is Orc)
                        {
                            Console.Write("O");
                        }
                        else if (creature is Elf)
                        {
                            Console.Write("E");
                        }
                        else if (creature is Birds bird)
                        {

                            Console.Write(bird.Symbol);
                        }
                        else if (creature is Animals)
                        {
                            Console.Write("A");
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine(Box.Vertical);

                if (y < _map.SizeY - 1)
                {
                    Console.Write(Box.MidLeft);
                    for (int x = 0; x < _map.SizeX; x++)
                    {
                        Console.Write(Box.Horizontal);
                    }
                    Console.WriteLine(Box.MidRight);
                }
            }

            Console.Write(Box.BottomLeft);
            for (int x = 0; x < _map.SizeX; x++)
            {
                Console.Write(Box.Horizontal);
            }
            Console.WriteLine(Box.BottomRight);
        }
    }
}
