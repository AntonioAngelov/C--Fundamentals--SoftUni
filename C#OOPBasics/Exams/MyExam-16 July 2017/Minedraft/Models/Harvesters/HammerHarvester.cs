public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, 
        double energyRequirement) 
        : base(id, oreOutput + oreOutput * 2
            , energyRequirement + energyRequirement)
    {}

    public override string ToString()
    {
        return $"Hammer Harvester - {this.Id}" + base.ToString();
    }
}
