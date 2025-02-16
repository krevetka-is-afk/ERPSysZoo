namespace ERP.Services;

public class ZooStatsService
{
    private readonly AnimalService _animalService;
    private readonly WorkerService _workerService;
    private readonly InventoryService _inventoryService;

    public ZooStatsService(AnimalService animalService, WorkerService workerService, InventoryService inventoryService)
    {
        _animalService = animalService;
        _workerService = workerService;
        _inventoryService = inventoryService;
    }
    
    public void ShowStats()
    {
        Console.WriteLine($"Total Animals: {_animalService.GetAnimals.Count} –– Food: {_animalService.TotalAnimalsFood}");
        Console.WriteLine($"Total Animals in Contact Zoo: {_animalService.GetContactZooAnimals().Count}");
        Console.WriteLine($"Total Workers: {_workerService.GetWorkers.Count} –– Food: {_workerService.TotalWorkersFood}");
        Console.WriteLine($"Total Things: {_inventoryService.Things.Count}");
        Console.WriteLine($"Total Food: {_animalService.TotalAnimalsFood + _workerService.TotalWorkersFood}");
    }
}