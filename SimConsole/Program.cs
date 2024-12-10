using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;


        BigBounceMap bounceMap = new(8, 6);

        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 5, CanFly = true },
            new Birds { Description = "Ostriches", Size = 4, CanFly = false }
        };

        List<Point> points = new List<Point>
        {
            new Point(0, 0),  
            new Point(7, 0),
            new Point(7, 5),
            new Point(0, 5),   
            new Point(3, 3),
        };

        string moves = "druldlurdlrrudlrludr";

        Simulation simulation = new Simulation(bounceMap, creatures, points, moves);

        MapVisualizer mapVisualizer = new MapVisualizer(bounceMap);

        mapVisualizer.Draw();
        Console.WriteLine("Press any key to start simulation...");
        Console.ReadKey();



        while (!simulation.Finished)
        {
            simulation.Turn();
            mapVisualizer.Draw();
            Console.WriteLine($"Current Move: {simulation.CurrentMoveName.ToUpper()}");
            Console.WriteLine("Press any key for next turn...");
            Console.ReadKey();
        }

        Console.WriteLine("Simulation Finished!");

        

    }
}

