using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private Dictionary<string, Harvester> harversters;
    private Dictionary<string, Provider> providers;

    public DraftManager()
    {
        this.mode = "Full";
        this.totalMinedOre = 0.0;
        this.totalStoredEnergy = 0.0;
        this.harversters = new Dictionary<string, Harvester>();
        this.providers =new Dictionary<string, Provider>();
    }

    
    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            var id = arguments[1];
            var oreOutput = double.Parse(arguments[2]);
            var energyRequirement = double.Parse(arguments[3]);

            switch (type)
            {
                case "Sonic":
                    var sonicFactor = int.Parse(arguments[4]);
                    this.harversters.Add(id, HarvesterFactory.CreateHarvester(type, id, oreOutput, energyRequirement, sonicFactor));
                    break;
                case "Hammer":
                    this.harversters.Add(id, HarvesterFactory.CreateHarvester(type, id, oreOutput, energyRequirement, 0));
                    break;
            }

            return $"Successfully registered {type} Harvester - {id}";

        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
        
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            var id = arguments[1];
            var energyOutput = double.Parse(arguments[2]);

            switch (type)
            {
                case "Solar":
                    this.providers.Add(id, ProviderFactory.CreateProvider(type, id, energyOutput));
                    break;
                case "Pressure":
                    this.providers.Add(id, ProviderFactory.CreateProvider(type, id, energyOutput));
                    break;
            }

            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    private string GetDayMessage(double summedEnergyOutput, double summedOreOutput)
    { 
        StringBuilder message = new StringBuilder();
        message.Append("A day has passed.")
            .Append(Environment.NewLine)
            .Append($"Energy Provided: {summedEnergyOutput}")
            .Append(Environment.NewLine)
            .Append($"Plumbus Ore Mined: {summedOreOutput}");

        return message.ToString();

    }

    public string Day()
    {
        var daysEnergy = this.providers.Values.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += daysEnergy;
        double neededEnery = 0;
        double daysOreOutput = 0;

        switch (this.mode)
        {
            case "Half":
                neededEnery = this.harversters.Values.Sum(h => h.EnergyRequirement * 0.6);
                if (neededEnery <= this.totalStoredEnergy)
                {
                    daysOreOutput = this.harversters.Values.Sum(h => h.OreOutput * 0.5);
                    this.totalMinedOre += daysOreOutput;
                    this.totalStoredEnergy -= neededEnery;
                }
                break;
            case "Energy":
                break;
            default:
                neededEnery = this.harversters.Values.Sum(h => h.EnergyRequirement);
                if (neededEnery <= this.totalStoredEnergy)
                {
                    daysOreOutput = this.harversters.Values.Sum(h => h.OreOutput);
                    this.totalMinedOre += daysOreOutput;
                    this.totalStoredEnergy -= neededEnery;
                }
                break;
        }

        return GetDayMessage(daysEnergy, daysOreOutput);
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (providers.ContainsKey(id))
        {
            return this.providers[id].ToString();
        }
        else if (harversters.ContainsKey(id))
        {
            return this.harversters[id].ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }
    public string ShutDown()
    {
        StringBuilder result = new StringBuilder();
        result.Append("System Shutdown")
            .Append(Environment.NewLine)
            .Append($"Total Energy Stored: {this.totalStoredEnergy}")
            .Append(Environment.NewLine)
            .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return result.ToString();
    }

}

