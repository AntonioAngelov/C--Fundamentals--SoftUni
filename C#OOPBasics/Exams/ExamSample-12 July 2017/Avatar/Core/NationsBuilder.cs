using System;
using System.Collections.Generic;
using System.Text;

public class NationsBuilder
{
    private AirNation airNation;
    private WaterNation waterNation;
    private FireNation fireNation;
    private EarthNation earthNation;
    private StringBuilder warsRecord;
    private int warsCount;

    public NationsBuilder()
    {
        this.airNation = new AirNation();
        this.waterNation = new WaterNation();
        this.fireNation = new FireNation();
        this.earthNation = new EarthNation();
        this.warsRecord = new StringBuilder();
        this.warsCount = 0;
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondaryParam = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                this.airNation.AddBender(new AirBender(name, power, secondaryParam));
                break;
            case "Water":
                this.waterNation.AddBender(new WaterBender(name, power, secondaryParam));
                break;
            case "Fire":
                this.fireNation.AddBender(new FireBender(name, power, secondaryParam));
                break;
            case "Earth":
                this.earthNation.AddBender(new EarthBender(name, power, secondaryParam));
                break;
        }

    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var addinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                this.airNation.AddMonument(new AirMonument(name, addinity));
                break;
            case "Water":
                this.waterNation.AddMonument(new WaterMonument(name, addinity));
                break;
            case "Fire":
                this.fireNation.AddMonument(new FireMonument(name, addinity));
                break;
            case "Earth":
                this.earthNation.AddMonument(new EarthMonument(name, addinity));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        switch (nationsType)
        {
            case "Air":
                return airNation.ToString();
                break;
            case "Water":
                return waterNation.ToString();
                break;
            case "Fire":
                return fireNation.ToString();
                break;
            default:
                return earthNation.ToString();
                break;
        }

    }

    public void IssueWar(string nationsType)
    {
        this.warsCount += 1;
        this.warsRecord.Append($"War {warsCount} issued by {nationsType}")
            .Append(Environment.NewLine);

        var airNationPower = this.airNation.GetTotalPower();
        var waterNationPower = this.waterNation.GetTotalPower();
        var fireNationPower = this.fireNation.GetTotalPower();
        var earthNationPower = this.earthNation.GetTotalPower();

        if (airNationPower > waterNationPower 
            && airNationPower > fireNationPower
            && airNationPower > earthNationPower)
        {
            waterNation.DestroyNation();
            fireNation.DestroyNation();
            earthNation.DestroyNation();
        }
        else if (waterNationPower > airNationPower
            && waterNationPower > fireNationPower
            && waterNationPower > earthNationPower)
        {
            airNation.DestroyNation();
            fireNation.DestroyNation();
            earthNation.DestroyNation();
        }
        else if (fireNationPower > airNationPower
            && fireNationPower > waterNationPower
            && fireNationPower > earthNationPower)
        {
            airNation.DestroyNation();
            waterNation.DestroyNation();
            earthNation.DestroyNation();
        }
        else if (earthNationPower > airNationPower
            && earthNationPower > fireNationPower
            && earthNationPower > waterNationPower)
        {
            airNation.DestroyNation();
            fireNation.DestroyNation();
            waterNation.DestroyNation();
        }
    }

    

    public string GetWarsRecord()
    {
        var record = this.warsRecord.Remove(warsRecord.Length - 1, 1).ToString();

        return record;
    }
}

