namespace ERPSysZoo.Models;

class Rabbit : Herbo
{
    public Rabbit(int food, int kindness) : base(food, kindness)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Rabbit sound");
    }
}