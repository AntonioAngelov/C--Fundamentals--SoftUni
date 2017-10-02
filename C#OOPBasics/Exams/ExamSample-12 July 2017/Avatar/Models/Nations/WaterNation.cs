using System;
using System.Linq;

public class WaterNation : Nation
{
    public override int GetBonusPercentage()
    {
        return this.Monuments.Sum(m =>
        {
            var monument = m as WaterMonument;
            return monument.WaterAffinity;
        });
    }

    public override string ToString()
    {
        return "Water Nation" + Environment.NewLine + base.ToString();
    }
}

