namespace Simulator.Maps;

public interface IMappable
{
    Map? Map { get; }
    Point Position { get; }
    char Symbol { get; }

    public string ToString();

    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);
}
