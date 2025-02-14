namespace ERPSysZoo.Models;

public class Tiger(int food) : Predator(food)
{
    public override void MakeSound()
    {
        Console.WriteLine("I'm a Tiger");
    }
}