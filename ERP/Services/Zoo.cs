using ERP.Models;

namespace ERP.Services;

public class Zoo
{
    private readonly List<Animal> _animals = new();
    private readonly List<Thing> _things = new();
    private readonly List<Worker> _workers = new();
    private readonly VetClinic _vetClinic;
    
    private int _totalAnimals = 0;
    private int _totalThings = 0;
    private int _totalWorkers = 0;
    private int _totalAnimalsFood = 0;
    private int _totalWorkersFood = 0;

    public Zoo(VetClinic vetClinic)
    {
        _vetClinic = vetClinic;
    }

    public void AddAnimal(Animal animal)
    {
        if (!_vetClinic.CheckHealth(animal))
            Console.WriteLine($"Animal {animal.GetType().Name} is not healthy, so we can't add it");
        _animals.Add(animal);
        _totalAnimals++;
        _totalAnimalsFood += animal.Food;
    }

    public void AddThing(Thing thing)
    {
        _things.Add(thing);
        _totalThings++;
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        _totalWorkers++;
        _totalWorkersFood += worker.Food;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Total Animals: {_totalAnimals} –– Food: {_totalAnimalsFood}");
        Console.WriteLine($"Total Workers: {_totalWorkers} –– Food: {_totalWorkersFood}");
        Console.WriteLine($"Total Things: {_totalThings}");
    }

    public void ShowAnimals()
    {
        Console.WriteLine($"List of {_animals.Count} animals in this Zoo");
        foreach (var animal in _animals)
        {
            Console.WriteLine($"{animal.GetType().Name} consume food {animal.Food} kg/day");   
        }
    }
    
    public List<Animal> GetAnimals() => _animals;
    public List<Animal> GetContactAnimals() => _animals.OfType<Herbo>().Where(herbo => herbo.Kindness > 5).ToList<Animal>();
    public List<Thing> GetThings() => _things;
    public List<Worker> GetWorkers() => _workers;
    

    public void ShowContactZooAnimals()
    {
        Console.WriteLine("List of animals: which can be safely added in Contact Zoo");
        List<Animal> contactAnimals = GetContactAnimals();
        foreach (var animal in contactAnimals)
        {
            Console.WriteLine($"{animal.GetType().Name} with kindness {{animal.Kindness}}");
        }
    }

    public void ShowThings()
    {
        Console.WriteLine("List of things: which exist in Zoo");
        foreach (var thing in _things)
        {
            Console.WriteLine($"{thing.GetType().Name} _№_ {thing.Number}");
        }
    }

    public void ShowWorkers()
    {
        Console.WriteLine("List of Workers of the Zoo");
        foreach (var worker in _workers)
        {
            Console.WriteLine($"{worker.Name} has Id: {worker.Number}");
        }
    }
    
}