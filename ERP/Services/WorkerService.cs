using ERP.Models;
namespace ERP.Services;

public class WorkerService
{
    private List<Worker> _workers = new();
    public IReadOnlyList<Worker> GetWorkers => _workers;
    public int TotalWorkers { get; private set; } = 0;
    public int TotalWorkersFood { get; private set; } = 0;

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        TotalWorkers++;
        TotalWorkersFood += worker.Food;
    }
}