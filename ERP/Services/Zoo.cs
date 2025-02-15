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
    
    public List<Animal> GetAnimals => _animals;
    public List<Animal> GetContactAnimals => _animals.OfType<Herbo>().Where(herbo => herbo.Kindness > 5).ToList<Animal>();
    public List<Thing> GetThings => _things;
    public List<Worker> GetWorkers => _workers;
    public int GetTotalAnimals => _totalAnimals;
    public int GetTotalThings => _totalThings;
    public int GetTotalWorkers => _totalWorkers;
    public int GetTotalAnimalsFood => _totalAnimalsFood;
    public int GetTotalWorkersFood => _totalWorkersFood;

    public Zoo(VetClinic vetClinic)
    {
        _vetClinic = vetClinic;
    }

    public void AddAnimal(Animal animal)
    {
        if (_vetClinic.CheckHealth(animal))
        {
            _animals.Add(animal);
            _totalAnimals++;
            _totalAnimalsFood += animal.Food;
        }
        else
        {
            Console.WriteLine($"Animal {animal.GetType().Name} is not healthy, so we can't add it");
        }
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
        Console.WriteLine($"Total Animals: {GetTotalAnimals} –– Food: {GetTotalAnimalsFood}");
        Console.WriteLine($"Total Animals in Contact Zoo: {GetContactAnimals.Count()}");
        Console.WriteLine($"Total Workers: {GetTotalWorkers} –– Food: {GetTotalWorkersFood}");
        Console.WriteLine($"Total Things: {GetTotalThings}");
    }

    public void ShowAnimals()
    {
        List<Animal> animals = GetAnimals;
        Console.WriteLine($"List of {animals.Count()} animals in this Zoo");
        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.GetType().Name} consume food {animal.Food} kg/day");   
        }
    }
    
    public void ShowContactZooAnimals()
    {
        Console.WriteLine("List of animals: which can be safely added in Contact Zoo");
        List<Animal> contactAnimals = GetContactAnimals;
        foreach (var animal in contactAnimals)
        {
            Console.WriteLine($"{animal.GetType().Name}");
        }
    }

    public void ShowThings()
    {
        List<Thing> things = GetThings;
        Console.WriteLine("List of things: which exist in Zoo");
        foreach (var thing in things)
        {
            Console.WriteLine($"{thing.GetType().Name} _№_ {thing.Number}");
        }
    }

    public void ShowWorkers()
    {
        List<Worker> workers = GetWorkers;
        Console.WriteLine("List of Workers of the Zoo");
        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name} has Id: {worker.Number}");
        }
    }
    
}