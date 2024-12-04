using Simulator;
using System.Drawing;

public class Birds : Animals
{
    public bool CanFly { get; init; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info
    {
        get
        {
            string flyStatus = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyStatus}) <{Size}>";
        }
    }

    public override void Go(Direction direction)
    {
        if (Map == null || Position == null)
            throw new InvalidOperationException("Ptak nie znajduje się na mapie");

        if (CanFly)
        {
            var firstStep = Map.Next(Position.Value, direction);
            var secondStep = Map.Next(firstStep, direction);

            if (Map.Exist(secondStep))
            {
                Map.Move(this, Position.Value, secondStep);
                Position = secondStep;
            }
        }
        else
        {
            var diagonalStep = Map.NextDiagonal(Position.Value, direction);

            if (Map.Exist(diagonalStep))
            {
                Map.Move(this, Position.Value, diagonalStep);
                Position = diagonalStep;
            }
        }
    }
}