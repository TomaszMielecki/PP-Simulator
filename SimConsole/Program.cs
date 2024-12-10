using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;


        BigBounceMap map = new(8, 6);

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
            new Point(5, 5),
            new Point(0, 2),   
            new Point(3, 5),
        };

        string moves = "druldlurdlrrudlrludd";

        Simulation simulation = new Simulation(map, creatures, points, moves);

        SimulationHistory simulationHistory = new SimulationHistory(simulation);

        MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);
        mapVisualizer.Draw();
        Console.WriteLine("Press any key to start simulation...");
        Console.ReadKey();

        int turnCounter = 0;

        while (!simulation.Finished)
        {
            simulation.Turn();
            simulationHistory.SaveState(turnCounter);
            mapVisualizer.Draw();
            Console.WriteLine($"Current Move: {simulation.CurrentMappable.GetType().Name} moves {simulation.CurrentMoveName.ToUpper()}");

            Console.WriteLine("Press any key for next turn...");
            Console.ReadKey();
            turnCounter++;
        }

        Console.WriteLine("Simulation Finished!");

        Console.WriteLine("Displaying states at specific turns:");


        simulationHistory.Replay(5);
        mapVisualizer.Draw(false);
        Console.WriteLine("Press any key to continue to 10th turn...");
        Console.ReadKey();


        simulationHistory.Replay(10);
        mapVisualizer.Draw(false);
        Console.WriteLine("Press any key to continue to 15th turn...");
        Console.ReadKey();


        simulationHistory.Replay(15);
        mapVisualizer.Draw(false);
        Console.WriteLine("Press any key to continue to 20th turn...");
        Console.ReadKey();


        simulationHistory.Replay(20);
        mapVisualizer.Draw(false);
        Console.WriteLine("Press any key to end");
        Console.ReadKey();

        

    }
}

