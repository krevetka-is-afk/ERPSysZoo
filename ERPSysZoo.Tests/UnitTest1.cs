using ERPSysZoo.Models;
using ERPSysZoo.Services;

namespace ERPSysZoo.Tests;

using Xunit;

public class AnimalTests
{
    [Fact]
    public void Animal_ShouldHaveCorrectProperties()
    {
        var monkey = new Monkey(5, 7); // 5 кг еды, доброта 7

        Assert.Equal(5, monkey.Food);
        Assert.Equal(7, monkey.Kindness);
        Assert.InRange(monkey.Kindness, 0, 10);
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