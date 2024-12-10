using Simulator;
using System.Reflection.Emit;
using System.Xml.Linq;

public class Orc : Creature
{
    public override char Symbol => 'O';
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        set => _rage = Validator.Limiter(value, 0, 10);
    }


    public void Hunt()
    {

    }

    public Orc() : base() { }

    public Orc(string name, int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }

    public new string Greeting { get; set; }


    public override int Power
    {
        get { return 7 * Level + 3 * Rage; }
    }

    public override string Info
    {
        get { return $"{Name} [{Level}][{Rage}]"; }
    }
}