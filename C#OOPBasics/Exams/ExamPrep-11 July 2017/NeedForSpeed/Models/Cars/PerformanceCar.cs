using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction,
        int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower + (horsepower * 50) / 100, acceleration, suspension - (suspension * 25) / 100, durability)
    {
        this.addOns = new List<string>();
    }

    public override void Tune(int index, string addon)
    {
        base.Tune(index, addon);
        this.addOns.Add(addon);
    }
    
    public override string ToString()
    {
        string toPrint = this.addOns.Count != 0 ? string.Join(", ", this.addOns) : "None";

        return base.ToString() 
            + Environment.NewLine 
            + $"Add-ons: {toPrint}";
    }
}
