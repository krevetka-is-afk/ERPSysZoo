using ERPSysZoo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERPSysZoo.DI;


public static class DependencyInjection
{
    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<VetClinic>();
        services.AddSingleton<Zoo>();
        return services.BuildServiceProvider();
    }
}