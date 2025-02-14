using ERPSysZoo.DI;
using ERPSysZoo.Models;
using ERPSysZoo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERPSysZoo;

public static class Program
{
    public static void Main(string[] args)
    {
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
                default:
                    Console.WriteLine("Неверный ввод!");
                    break;
            }
        }
    }
}
