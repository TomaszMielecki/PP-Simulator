using Simulator.Maps;

namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator\n");
            Lab5a();
            Lab5b();
            
            Console.ReadLine();

        }
        static void Lab5a()
        {
            try
            {
                Rectangle pros1 = new Rectangle(3, 3, 9, 9);
                Console.WriteLine("Utworzono prostokąt" + pros1.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error  : " + ex.Message);
            }
            try
            {
                Rectangle pros2 = new Rectangle(5, 5, 5, 8);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            try
            {

                Point p1 = new Point(3, 3);
                Point p2 = new Point(6, 8);
                Rectangle pros3 = new Rectangle(p1, p2);
                Console.WriteLine("Prostokąt utworzony z punktów: " + pros3.ToString());

                Point puntkDoSprawdzenia= new Point(4, 4);
                Console.WriteLine($"Czy {pros3} zawiera punkt {puntkDoSprawdzenia}? " + pros3.Contains(puntkDoSprawdzenia));

                Point punktSpoza= new Point(10, 12);
                Console.WriteLine($"Czy {pros3} zawiera punkt {punktSpoza}? " + pros3.Contains(punktSpoza));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

        }

        static void Lab5b()
        {
            try
            {
                SmallSquareMap mapa1 = new SmallSquareMap(12);
                Console.WriteLine("Utworzyłeś mapę o rozmiarze : " + mapa1.Size); // sprawdzamy czy mozna utworzyc

            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            try
            {
                SmallSquareMap mapa2 = new SmallSquareMap(13);
                Point start = new Point(3, 3);
                Point next = mapa2.Next(start, Direction.Left);
                Console.WriteLine($"Ruch w lewo punkt z {start} do {next}"); // sprawdzamy czy można się poruszać w linii prostej

                Point diagonal = mapa2.NextDiagonal(start, Direction.Right);
                Console.WriteLine($"Na ukos w prawo do góry, punkt z {start} do {diagonal}"); // sprawdzamy czy można się poruszać na ukos

                Point pozaMapa = new Point(12, 12);
                Point calkowiciePozaMapa = mapa2.Next(pozaMapa, Direction.Up);
                Console.WriteLine($"Po ruchu poza mapę punkt z {pozaMapa} do {calkowiciePozaMapa} - powinien zostać ten sam"); // sprawdzamy czy granica mapy działa
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }



    }
}