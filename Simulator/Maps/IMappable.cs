namespace Simulator.Maps;

public interface IMappable
{
    Map? Map { get; }
    Point? Position { get; }
    char Symbol { get; }
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point position);
}
