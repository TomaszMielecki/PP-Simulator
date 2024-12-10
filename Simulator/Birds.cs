using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get
        {
            string flyStatus = CanFly ? "(fly+)" : "(fly-)";
            return $"{Description} {flyStatus} <{Size}>";
        }
    }

    public override char Symbol => CanFly ? 'B' : 'b';

    protected override Point GetNewPosition(Direction direction) => CanFly
        ? Map.Next(Map.Next(Position, direction), direction)
        : Map.NextDiagonal(Position, direction);
}