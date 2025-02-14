namespace ERP.Models;

public abstract class Herbo : Animal
{
    private int _kindness;

    public int Kindness
    {
        get => _kindness;
        private set
        {
            if (value is < 0 or > 10) 
                throw new ArgumentOutOfRangeException(nameof(value), "Kindness must be between 0 and 10");
            _kindness = value;
        }
    }
    
    protected Herbo(int food, int kindness) : base(food)
    {
        Kindness = kindness;
    }
}