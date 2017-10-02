using System;
using System.Text;

public class Provider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput 
    {
        get { return energyOutput; }
        private set
        {
            if (value < 0.0001 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput  = value;
        }
    }


    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(Environment.NewLine)
            .Append($"Energy Output: {this.EnergyOutput}");

        return result.ToString();
    }
}
