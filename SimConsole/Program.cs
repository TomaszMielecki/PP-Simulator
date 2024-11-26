using Simulator;
using Simulator.Maps;

namespace SimConsole;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            simulation.Turn();
            mapVisualizer.Draw();
            Console.WriteLine($"Current Move: {simulation.CurrentMoveName.ToUpper()}");
            Console.WriteLine("Press any key for next turn...");
            Console.ReadKey();
        }

        Console.WriteLine("Simulation Finished!");

        Console.ReadLine();    
    }
}
