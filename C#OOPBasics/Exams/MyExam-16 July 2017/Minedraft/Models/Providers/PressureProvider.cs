public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput + energyOutput * 0.5)
    {
    }

    public override string ToString()
    {
        return $"“Pressure Provider - {this.Id}" + base.ToString();
    }
}

