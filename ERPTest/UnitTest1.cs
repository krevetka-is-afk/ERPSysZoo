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

public class AnimalServiceTests
{
    [Fact]
    public void ContactZoo_ShouldHaveCorrectAnimals()
    {
        var animalService = new AnimalService(new VetClinic());
        
        var leo = new Tiger(29);
        var rabbit = new Rabbit(3, 8);
        var monkey = new Monkey(5, 2);

        animalService.AddAnimal(leo);
        animalService.AddAnimal(monkey);
        animalService.AddAnimal(rabbit);

        var contactZooAnimals = animalService.GetContactZooAnimals();
        
        Assert.InRange(contactZooAnimals.Count, 0, 1);
    }

    [Fact]
    public void Zoo_ShouldHaveCorrectAmountOfAnimals()
    {
        var animalService = new AnimalService(new VetClinic());

        var leo = new Tiger(29);
        var rabbit = new Rabbit(3, 8);
        var monkey = new Monkey(5, 2);

        animalService.AddAnimal(leo);
        animalService.AddAnimal(monkey);
        animalService.AddAnimal(rabbit);
        
        Assert.InRange(animalService.TotalAnimals, 0, 3);
        Assert.InRange(animalService.GetAnimals.Count(), 0, 3);
    }
    
    [Fact]
    public void Zoo_ShouldCalculateTotalFood()
    {
        var animalService = new AnimalService(new VetClinic());
        
        animalService.AddAnimal(new Tiger(10));
        animalService.AddAnimal(new Monkey(5, 6));

        Assert.InRange<int>(animalService.TotalAnimalsFood, 0, 15);
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
        
        var animalService = serviceProvider.GetService<AnimalService>();
        Assert.NotNull(animalService);
        
        var inventoryService = serviceProvider.GetService<InventoryService>();
        Assert.NotNull(inventoryService);
        
        var workerService = serviceProvider.GetService<WorkerService>();
        Assert.NotNull(workerService);
        
        var zooStatsService = serviceProvider.GetService<ZooStatsService>();
        Assert.NotNull(zooStatsService);

        var zoo = serviceProvider.GetService<Zoo>();
        Assert.NotNull(zoo);
    }
}

public class InventoryServiceTests
{
    [Fact]
    public void Inventory_ShouldHaveCorrectItems()
    {
        var inventoryService = new InventoryService();
        
        var computer = new Computer();
        var table = new Table();
        
        inventoryService.AddThing(computer);
        inventoryService.AddThing(table);
        
        Assert.Equal(2, inventoryService.Things.Count);
    }
}

public class WorkerServiceTests
{
    [Fact]
    public void Worker_ShouldHaveCorrectProperties()
    {
        var workerService = new WorkerService();
        
        var vasya = new Worker("Vasya", 1);
        var gena = new Worker("Gena", 2);
        
        workerService.AddWorker(vasya);
        workerService.AddWorker(gena);
        
        Assert.Equal(2, workerService.GetWorkers.Count);
        Assert.Equal(2, workerService.TotalWorkers);
    }
}