namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator\n");
            Lab5a();
            
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
                Console.WriteLine("Error : " + ex.Message);
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

        

    }
}