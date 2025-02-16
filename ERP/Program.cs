using ERP.DI;
using ERP.Models;
using ERP.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = DependencyInjection.ConfigureServices();
var zoo = serviceProvider.GetRequiredService<Zoo>();

while (true)
{
    Console.WriteLine("\nМеню:");
    Console.WriteLine("1. Добавить животное");
    Console.WriteLine("2. Добавить вещь");
    Console.WriteLine("3. Добавить человека");
    Console.WriteLine("4. Показать всех животных");
    Console.WriteLine("5. Показать всех животных в контактном зоопарке");
    Console.WriteLine("6. Показать инвентарь");
    Console.WriteLine("7. Показать работников");
    Console.WriteLine("8. Показать общую статистику");
    Console.WriteLine("9. Выход");
    Console.Write("Выберите действие: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("1. Добавить Обезьяну");
            Console.WriteLine("2. Добавить Кролика");
            Console.WriteLine("3. Добавить Волка");
            Console.WriteLine("4. Добавить Тигра");
            switch (Console.ReadLine())
            {
                case "1":
                    zoo.AddAnimal(new Monkey(new Random().Next(1, 4), new Random().Next(0, 10))); // Демо-данные
                    break;
                case "2":
                    zoo.AddAnimal(new Rabbit(new Random().Next(1, 4), new Random().Next(0, 10)));
                    break;
                case "3":
                    zoo.AddAnimal(new Wolf(new Random().Next(3, 15)));
                    break;
                case "4":
                    zoo.AddAnimal(new Tiger(new Random().Next(3, 15)));
                    break;
                default:
                    Console.WriteLine("Неверный ввод!");
                    break;
            }
            
            break;
        case "2":
            Console.WriteLine("1. Добавить Компьютер");
            Console.WriteLine("2. Добавить Стол");
            switch (Console.ReadLine())
            {
                case "1":
                    zoo.AddThing(new Computer());
                    break;
                case "2":
                    zoo.AddThing(new Table());
                    break;
                default:
                    Console.WriteLine("Неверный ввод!");
                    break;
            }
            break;
        case "3":
            zoo.AddWorker(new Worker($"Алексей – {new Random().Next(1,100)}", new Random().Next(0, 3)));
            break;
        case "4":
            zoo.ShowAnimals();
            break;
        case "5":
            zoo.ShowContactZooAnimals();
            break;
        case "6":
            zoo.ShowThings();
            break; 
        case "7":
            zoo.ShowWorkers();
            break;
        case "8":
            zoo.ShowStats();
            break;
        case "9":
            return;
        default:
            Console.WriteLine("Неверный ввод!");
            break;
    }
}