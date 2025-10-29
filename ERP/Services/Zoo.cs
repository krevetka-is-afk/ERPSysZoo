using ERP.Models;

namespace ERP.Services;

public class Zoo
{
    private readonly AnimalService _animalService;
    private readonly WorkerService _workerService;
    private readonly InventoryService _inventoryService;
    private readonly ZooStatsService _statsService;

    public Zoo(AnimalService animalService, WorkerService workerService, InventoryService inventoryService,
        ZooStatsService statsService)
    {
        _animalService = animalService;
        _workerService = workerService;
        _inventoryService = inventoryService;
        _statsService = statsService;
    }

    public void AddAnimal(Animal animal)
    {
        if (!_animalService.AddAnimal(animal))
            Console.WriteLine($"Animal {animal.GetType().Name} is not healthy, so we can't add it");
    }

    public void AddThing(Thing thing)
    {
        _inventoryService.AddThing(thing);
    }

    public void AddWorker(Worker worker)
    {
        _workerService.AddWorker(worker);
    }

    public void ShowStats()
    {
        _statsService.ShowStats();
    }

    public void ShowAnimals()
    {
        Console.WriteLine($"List of {_animalService.GetAnimals.Count} animals in this Zoo");
        foreach (var animal in _animalService.GetAnimals)
        {
            Console.WriteLine($"{animal.GetType().Name} consume food {animal.Food} kg/day");
        }
    }

    public void ShowContactZooAnimals()
    {
        Console.WriteLine("List of animals which can be safely added to the Contact Zoo:");
        foreach (var animal in _animalService.GetContactZooAnimals())
        {
            Console.WriteLine($"{animal.GetType().Name}");
        }
    }

    public void ShowThings()
    {
        Console.WriteLine("List of things in Zoo:");
        foreach (var thing in _inventoryService.Things)
        {
            Console.WriteLine($"{thing.GetType().Name} _№_ {thing.Number}");
        }
    }

    public void ShowWorkers()
    {
        Console.WriteLine("List of Workers in the Zoo:");
        foreach (var worker in _workerService.GetWorkers)
        {
            Console.WriteLine($"{worker.Name} has Id: {worker.Number}");
        }
    }
}