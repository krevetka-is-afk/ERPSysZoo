using ERP.DI;
using ERP.Models;
using ERP.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERPTest;
using Xunit;

public class AnimalTests
{
    [Fact]
    public void Herbo_ShouldHaveCorrectProperties()
    {
        var monkey = new Monkey(5, 7);

        Assert.Equal(5, monkey.Food);
        Assert.Equal(7, monkey.Kindness);
        Assert.InRange(monkey.Kindness, 0, 10);
        
        // var rabbit = new Rabbit(5, 12);
        
    }
    
    [Fact]
    public void Predator_ShouldHaveCorrectProperties()
    {
        var wolf = new Wolf(10);
        Assert.Equal(10, wolf.Food);
    }
}


public class VetClinicTests
{
    [Fact]
    public void VetClinic_ShouldReturnBoolean()
    {
        var clinic = new VetClinic();
        var animal = new Tiger(10);

        var result = clinic.CheckHealth(animal);

        Assert.IsType<bool>(result);
    }
}

public class EntityFactoryTests
{
    [Fact]
    public void EntityFactory_ShouldAssignUniqueId()
    {
        int id1 = EntityFactory.GetNextId();
        int id2 = EntityFactory.GetNextId();
        Assert.NotEqual(id1, id2);
    }
}

public class ThingsTests
{
    [Fact]
    public void Things_ShouldHaveIds()
    {
        var laptop = new Computer();
        var table = new Table();
        
        var numLaptop = laptop.Number;
        var numTable = table.Number;
        
        Assert.NotEqual(-1, numLaptop);
        Assert.NotEqual(-1, numTable);
    }
}

public class WorkerTests
{
    [Fact]
    public void Worker_ShouldHaveCorrectProperties()
    {
        var workerA = new Worker("Andy", 1);
        var workerB = new Worker("Windy", 2);
        
        Assert.Equal("Andy", workerA.Name);
        Assert.Equal("Windy", workerB.Name);
        Assert.Equal(1, workerA.Food); // 1 kg/d is default 
        Assert.Equal(2, workerB.Food);
        Assert.NotEqual(-1, workerA.Number);
        Assert.NotEqual(-1, workerB.Number);
        
    }
}

public class ZooTests
{
    [Fact]
    public void ContactZoo_ShouldHaveCorrectAnimals()
    {
        var zoo = new Zoo(new VetClinic());

        var leo = new Tiger(29);
        var rabbit = new Rabbit(3, 8);
        var monkey = new Monkey(5, 2);

        zoo.AddAnimal(leo);
        zoo.AddAnimal(monkey);
        zoo.AddAnimal(rabbit);

        var contactZooAnimals = zoo.GetContactAnimals;
        
        Assert.InRange(contactZooAnimals.Count(), 0, 1);
    }

    [Fact]
    public void Zoo_ShouldHaveCorrectAmountOfAnimals()
    {
        var zoo = new Zoo(new VetClinic());

        var leo = new Tiger(29);
        var rabbit = new Rabbit(3, 8);
        var monkey = new Monkey(5, 2);

        zoo.AddAnimal(leo);
        zoo.AddAnimal(monkey);
        zoo.AddAnimal(rabbit);
        
        Assert.InRange(zoo.GetTotalAnimals, 0, 3);
        Assert.InRange(zoo.GetAnimals.Count(), 0, 3);
    }

    [Fact]
    public void Zoo_ShoudKnowsEverything()
    {
        var zoo = new Zoo(new VetClinic());
        var leo = new Tiger(29);
        var comp = new Computer();
        var person = new Worker("Andy", 1);
        
        zoo.AddAnimal(leo);
        zoo.AddThing(comp);
        zoo.AddWorker(person);
        
        Assert.InRange(zoo.GetTotalAnimals, 0, 1);
        Assert.Equal(1, zoo.GetTotalThings);
        Assert.Equal(1, zoo.GetTotalWorkers);
        
        Assert.Equal(1, zoo.GetTotalWorkersFood);
        
        // Assert.Contains(leo, zoo.GetAnimals);
        Assert.Contains(comp, zoo.GetThings);
        Assert.Contains(person, zoo.GetWorkers);
        
    }
    
    
    [Fact]
    public void Zoo_ShouldCalculateTotalFood()
    {
        var zoo = new Zoo(new VetClinic());
        zoo.AddAnimal(new Tiger(10));
        zoo.AddAnimal(new Monkey(5, 6));

        Assert.InRange(zoo.GetTotalAnimalsFood, 0, 15);
    }
}
public class DependencyInjectionTests
{
    [Fact]
    public void ConfigureServices_ShouldRegisterVetClinicAndZoo()
    {
        var serviceProvider = DependencyInjection.ConfigureServices();

        Assert.NotNull(serviceProvider);

        var vetClinic = serviceProvider.GetService<VetClinic>();
        Assert.NotNull(vetClinic);

        var zoo = serviceProvider.GetService<Zoo>();
        Assert.NotNull(zoo);
    }
}