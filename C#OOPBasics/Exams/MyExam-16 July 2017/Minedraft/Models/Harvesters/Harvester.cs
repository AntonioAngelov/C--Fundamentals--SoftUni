using System;
using System.Text;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement 
    {
        get { return energyRequirement; }
        private set
        {
            if (value < 0.0001 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }

            energyRequirement = value;
        }
    }
    
    public double OreOutput
    {
        get { return oreOutput ; }
        private set
        {
            if (value < 0.0001)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }

            oreOutput  = value;
        }
    }


    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(Environment.NewLine)
            .Append($"Ore Output: {this.OreOutput}")
            .Append(Environment.NewLine)
            .Append($"Energy Requirement: {this.EnergyRequirement}");

        return result.ToString();
    }
}
