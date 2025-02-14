namespace ERPSysZoo.Models;

public class Monkey : Herbo
{
    public Monkey(int food, int kindness) : base(food, kindness) { }

    public override void MakeSound()
    {
        Console.WriteLine("I'm Monkey");
    }
}