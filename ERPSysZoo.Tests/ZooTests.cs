// using ERPSysZoo.Models;
// using ERPSysZoo.Services;
//
// namespace ERPSysZoo.Tests;
//
// using Xunit;
//
// public class HerboTests
// {
//     [Fact]
//     public void Herbo_ShouldHaveCorrectProperties()
//     {
//         var monkey = new Monkey(5, 7);
//
//         Assert.Equal(5, monkey.Food);
//         Assert.Equal(7, monkey.Kindness);
//         Assert.InRange(monkey.Kindness, 0, 10);
//     }
// }
//
// public class PredatorTests
// {
//     [Fact]
//     public void Predator_ShouldHaveCorrectProperties()
//     {
//         var wolf = new Wolf(10);
//         Assert.Equal(10, wolf.Food);
//     }
// }
//
// public class VetClinicTests
// {
//     [Fact]
//     public void VetClinic_ShouldReturnBoolean()
//     {
//         var clinic = new VetClinic();
//         var animal = new Tiger(10);
//
//         var result = clinic.CheckHealth(animal);
//
//         Assert.IsType<bool>(result);
//     }
// }
//
// public class EntityFactoryTests
// {
//     [Fact]
//     public void EntityFactory_ShouldAssignUniqueId()
//     {
//         int id1 = EntityFactory.GetNextId();
//         int id2 = EntityFactory.GetNextId();
//         Assert.NotEqual(id1, id2);
//     }
// }
//
// public class ContactZooTests
// {
//     [Fact]
//     public void ContactZoo_ShouldHaveCorrectAnimals()
//     {
//         var zoo = new Zoo(new VetClinic());
//
//         var leo = new Tiger(29);
//         var rabbit = new Rabbit(3, 8);
//         var monkey = new Monkey(5, 2);
//         var worker = new Worker("Alex");
//
//         zoo.AddAnimal(leo);
//         zoo.AddAnimal(monkey);
//         zoo.AddAnimal(rabbit);
//         zoo.AddWorker(worker);
//
//         var contactZooAnimals = zoo.GetContactAnimals();
//     }
// }