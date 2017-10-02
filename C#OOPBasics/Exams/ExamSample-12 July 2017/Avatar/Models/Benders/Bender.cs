public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public int Power
    {
        get { return power; }
        private set { power = value; }
    }
    
    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public abstract double GetPower();
}
