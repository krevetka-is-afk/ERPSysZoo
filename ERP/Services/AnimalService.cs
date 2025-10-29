using ERP.Models;
namespace ERP.Services;

public class AnimalService
{
    private readonly List<Animal> _getAnimals = new();
    private readonly VetClinic _vetClinic;

    public List<Animal> GetAnimals => _getAnimals;
    public int TotalAnimalsFood { get; private set; } = 0;
    public int TotalAnimals { get; private set; } = 0;

    public AnimalService(VetClinic vetClinic)
    {
        _vetClinic = vetClinic;
    }
    public bool AddAnimal(Animal animal)
    {
        if (_vetClinic.CheckHealth(animal))
        {
            _getAnimals.Add(animal);
            TotalAnimalsFood += animal.Food;
            TotalAnimals++;
            return true;
        }
        return false;
    }

    public List<Animal> GetContactZooAnimals()
    {
        return _getAnimals.OfType<Herbo>().Where(herbo => herbo.Kindness > 5).ToList<Animal>();
    }
    
}