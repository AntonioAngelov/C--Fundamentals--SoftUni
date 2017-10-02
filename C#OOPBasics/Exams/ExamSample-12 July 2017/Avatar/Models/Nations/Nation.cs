using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public List<Monument> Monuments
    {
        get { return monuments; }
        protected set { monuments = value; }
    }

    public List<Bender> Benders
    {
        get { return this.benders; }
        protected set { benders = value; }
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public double GetBendersPower()
    {
        return this.Benders.Sum(b => b.GetPower());
    }

    public abstract int GetBonusPercentage();

    public double GetTotalPower()
    {
        var bendersPower = this.GetBendersPower();
        var bonusPercentage = GetBonusPercentage();

        return bendersPower + (bendersPower / 100) * bonusPercentage;
    }

    internal void DestroyNation()
    {
        this.monuments = new List<Monument>();
        this.benders = new List<Bender>();
    }


    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        if (this.Benders.Count == 0)
        {
            result.Append("Benders: None")
                .Append(Environment.NewLine);
        }
        else
        {
            result.Append("Benders:")
                .Append(Environment.NewLine);
        }

        foreach (var bender in this.Benders)
        {
            result.Append($"###{bender}")
                .Append(Environment.NewLine);
        }

        if (this.Monuments.Count == 0)
        {
            result.Append("Monuments: None");
        }
        else
        {
            result.Append("Monuments:");
        }

        foreach (var monument in this.Monuments)
        {
            result.Append(Environment.NewLine)
                .Append($"###{monument}");
        }

        return result.ToString();

    }
}

