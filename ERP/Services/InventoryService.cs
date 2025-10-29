using ERP.Models;

namespace ERP.Services;

public class InventoryService
{
    private readonly List<Thing> _things = new();

    public IReadOnlyList<Thing> Things => _things;

    public void AddThing(Thing thing)
    {
        _things.Add(thing);
    }
}