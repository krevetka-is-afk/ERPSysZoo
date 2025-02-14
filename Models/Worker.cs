namespace ERPSysZoo.Models;

public class Worker : IAlive, IInventory, IPerson
{
    public int Food { get; }
    public int Number { get; }
    public string Name { get; }

    public Worker(string name, int food = 0)
    {
        Name = name;
        Food = food;
        Number = EntityFactory.GetNextId();
    }
}