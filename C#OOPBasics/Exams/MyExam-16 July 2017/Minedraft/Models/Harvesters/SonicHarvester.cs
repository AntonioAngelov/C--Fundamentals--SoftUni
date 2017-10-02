public class SonicHarvester : Harvester
{
    private int sonicFactor ;

    public SonicHarvester(string id, double oreOutput, 
        double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement / sonicFactor)
    {
        this.SonicFactor = sonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        private set { sonicFactor = value; }
    }

    public override string ToString()
    {
        return $"Sonic Harvester - {this.Id}" + base.ToString();
    }
}

