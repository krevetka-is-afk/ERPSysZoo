using ERPSysZoo.Models;

namespace ERPSysZoo.Services;

public class VetClinic
{
    public bool CheckHealth(Animal animal)
    {
        return new Random().Next(0, 2) == 1;
    }
    
}