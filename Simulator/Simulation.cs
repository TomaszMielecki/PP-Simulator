using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {

        private int _currentMoveIndex = 0;


        /// <summary>
        /// Simulation's map.
        /// </summary>
        public Map Map { get; }


        /// <summary>
        /// Creatures moving on the map.
        /// </summary>
        public List<Creature> Creatures { get; }


        /// <summary>
        /// Starting positions of creatures.
        /// </summary>
        public List<Point> Positions { get; }


        /// <summary>
        /// Cyclic list of creatures moves. 
        /// Bad moves are ignored - use DirectionParser.
        /// First move is for first creature, second for second and so on.
        /// When all creatures make moves, 
        /// next move is again for first creature and so on.
        /// </summary>
        public string Moves { get; }


        /// <summary>
        /// Has all moves been done?
        /// </summary>
        public bool Finished = false;


        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public Creature CurrentCreature { get => Creatures[_currentMoveIndex % Creatures.Count]; }


        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName { get => Moves[_currentMoveIndex % Moves.Length].ToString().ToLower(); }


        /// <summary>
        /// Simulation constructor.
        /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from 
        /// number of starting positions.
        /// </summary>
        public Simulation(Map map, List<Creature> creatures,
            List<Point> positions, string moves)
        {

            if (creatures.Count == 0 || creatures == null)
            {
                throw new ArgumentException("Lista stworów nie może być pusta");
            }
            if (creatures.Count != positions.Count || positions == null)
            {
                throw new ArgumentException("Liczba stworów musi odpowiadać liczbie pozycji");
            }

            Map = map ?? throw new ArgumentNullException(nameof(map));
            Creatures = creatures;
            Positions = positions;
            Moves = moves;

            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].InitMapAndPosition(map, positions[i]);
            }
        }


        /// <summary>
        /// Makes one move of current creature in current direction.
        /// Throw error if simulation is finished.
        /// </summary>
        public void Turn() 
        {
            if (Finished)
            {
                throw new InvalidOperationException("Symulacja już się zakończyła.");
            }

            List<char> moveList = new List<char> { 'U', 'D', 'L', 'R' };
            char moveChar = moveList[_currentMoveIndex % moveList.Count];

            Direction direction;
            try
            {
                direction = DirectionParser.Parse(moveChar.ToString())[0];
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Zły znak ruchu: '{moveChar}'. Dopuszczalne są jedynie znaki: 'U', 'D', 'L', 'R'.");
            }

            CurrentCreature.Go(direction);

            _currentMoveIndex++;

            if (_currentMoveIndex >= Moves.Length)
            {
                Finished = true;
            }
        }
    }
}
