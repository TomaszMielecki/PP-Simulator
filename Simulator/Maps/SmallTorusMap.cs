﻿namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }

        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size), "Niestety rozmiar mapy musi mieścić się w przedziale pomiędzy 5, a 20.");

            Size = size;
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
        }

        public override Point Next(Point p, Direction d)
        {
            var newPoint = p.Next(d);
            int newX = (newPoint.X + Size) % Size;
            int newY = (newPoint.Y + Size) % Size;

            return new Point(newX, newY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var newPoint = p.NextDiagonal(d);
            int newX = (newPoint.X + Size) % Size;
            int newY = (newPoint.Y + Size) % Size;

            return new Point(newX, newY);
        }
    }
}
