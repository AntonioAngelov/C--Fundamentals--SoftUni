using System.Threading;

public class AirBender : Bender
{
    private double aerialIntegrity;
    
    public AirBender(string name, int power, double aerialIntegrity) 
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        private set { aerialIntegrity = value; }
    }

    public override double GetPower()
    {
        return this.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return $"Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}
