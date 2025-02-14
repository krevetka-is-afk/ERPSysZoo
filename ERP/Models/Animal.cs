namespace ERP.Models;

public abstract class Animal : IAlive, IInventory
{
    public int Food { get; protected set; }

    public int Number { get; protected set; }

    protected Animal(int food)
    {
        Food = food;
        Number = EntityFactory.GetNextId();
    }

    public abstract void MakeSound();
}