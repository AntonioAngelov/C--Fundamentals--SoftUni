public static class HarvesterFactory
{
    public static Harvester CreateHarvester(string type, string id, double oreOutput,double energyRequirement,int sonicFactor)
    {        
        if (type == "Hammer")
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
        else
        {
            return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
    }
}

