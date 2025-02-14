using ERP.DI;
using ERP.Models;
using ERP.Services;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceProvider = DependencyInjection.ConfigureServices();
var zoo = serviceProvider.GetRequiredService<Zoo>();

while (true)
{
    Console.WriteLine("\nМеню:");
    Console.WriteLine("1. Добавить животное");
    Console.WriteLine("2. Добавить вещь");
    Console.WriteLine("3. Добавить человека");
    Console.WriteLine("4. Показать всех животных");
    Console.WriteLine("5. Показать инвентарь");
    Console.WriteLine("6. Show stats");
    Console.WriteLine("7. Exit");
    Console.Write("Выберите действие: ");

    switch (Console.ReadLine())
    {
        case "1":
            zoo.AddAnimal(new Monkey(3, 7)); // Демо-данные
            break;
        case "2":
            zoo.AddThing(new Thing());
            break;
        case "3":
            zoo.AddWorker(new Worker("Алексей"));
            break;
        case "4":
            zoo.ShowAnimals();
            break;
        case "5":
            zoo.ShowThings();
            break;
        case "6":
            zoo.ShowStats();
            break;
        case "7":
            zoo.ShowStats();
            return;
        default:
            Console.WriteLine("Неверный ввод!");
            break;
    }
}