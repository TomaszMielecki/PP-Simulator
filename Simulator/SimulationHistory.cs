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
        private readonly List<SimulationState> _history = new List<SimulationState>();
        private readonly Simulation _simulation;

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation;
        }

        public void SaveState(int turn)
        {
            var state = new SimulationState
            {
                Turn = turn,
                ObjectPositions = new Dictionary<IMappable, Point>(),
                CurrentMove = _simulation.CurrentMoveName,
                CurrentMappable = _simulation.CurrentMappable
            };


            foreach (var creature in _simulation.IMappables)
            {
                state.ObjectPositions[creature] = creature.Position;
            }

            _history.Add(state);
        }

        public void Replay(int turn)
        {
            Console.Clear();

            var state = _history.FirstOrDefault(s => s.Turn == turn);
            if (state != null)
            {

                foreach (var creature in _simulation.IMappables)
                {
                    _simulation.Map.Remove(creature, creature.Position);
                }

                foreach (var entry in state.ObjectPositions)
                {
                    entry.Key.InitMapAndPosition(_simulation.Map, entry.Value);
                }

                Console.WriteLine($"Replaying turn {turn}, move: {state.CurrentMove.ToUpper()}");

                Console.WriteLine($"Next Move: {state.CurrentMappable.GetType().Name} will move {state.CurrentMove.ToUpper()}");
            }
            else
            {
                Console.WriteLine($"No state found for turn {turn}");
            }
        }

        private class SimulationState
        {
            public int Turn { get; set; }
            public Dictionary<IMappable, Point> ObjectPositions { get; set; }
            public string CurrentMove { get; set; }
            public IMappable CurrentMappable { get; set; }
        }
    }
}
