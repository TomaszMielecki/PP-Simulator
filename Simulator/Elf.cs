using System.ComponentModel.DataAnnotations;

namespace Simulator;

public class Elf : Creature
{
    private int _singCounter = 0;
    private int _agility;

    public Elf()
    {
    }
    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
    {
        Name = name;
        Level = level;
        Agility = agility;
    }

    public int Agility
    {
        get => _agility;
        init => _agility = Validator.Limiter(value, 0, 10);
    }

    public override int Power => Level * 8 + Agility * 2;

    public override string Info => $"{Name} [{Level}][{Agility}]";

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        _singCounter++;
        if (_singCounter % 3 == 0)
        {
            _agility++;
        }
    }
}