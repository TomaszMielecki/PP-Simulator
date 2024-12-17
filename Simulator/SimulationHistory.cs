using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class SimulationHistory
    {
        private Simulation _simulation { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public List<SimulationTurnLog> TurnLogs { get; } = [];
        // store starting positions at index 0

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ??
                throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;
            Run();
        }

        private void Run()
        {
            while (true)
            {
                var symbols = new Dictionary<Point, char>();

                foreach (var mappable in _simulation.IMappables)
                {
                    symbols[mappable.Position] = symbols.ContainsKey(mappable.Position) ? 'X' : mappable.Symbol;
                }

                TurnLogs.Add(new SimulationTurnLog
                {
                    Mappable = _simulation.CurrentMappable?.ToString() ?? string.Empty,
                    Move = _simulation.CurrentMoveName ?? string.Empty,
                    Symbols = symbols
                });

                if (_simulation.Finished) break;

                _simulation.Turn();
            }
    }
}
