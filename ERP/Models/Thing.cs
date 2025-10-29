namespace ERP.Models;

public class Thing : IInventory
{
    public int Number { get; } = EntityFactory.GetNextId();
}