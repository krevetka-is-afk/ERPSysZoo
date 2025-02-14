namespace ERPSysZoo.Models;

public class Wolf : Predator
{
    public Wolf(int food) : base(food)
    { }

    public override void MakeSound()
    {
        Console.WriteLine("Wolf is a wolf");
    }
}