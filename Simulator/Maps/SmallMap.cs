namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {

       

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

     
        }

        
    }
}
