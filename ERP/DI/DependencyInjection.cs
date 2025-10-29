using ERP.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.DI;

public static class DependencyInjection
{
    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        
        services.AddSingleton<VetClinic>();
        services.AddSingleton<AnimalService>();
        services.AddSingleton<InventoryService>();
        services.AddSingleton<WorkerService>();
        services.AddSingleton<ZooStatsService>();
        services.AddSingleton<Zoo>();
        
        return services.BuildServiceProvider();
    }
}