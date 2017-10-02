using System;
using System.Collections.Generic;
using System.Linq;

public class AirNation : Nation
{
    public override int GetBonusPercentage()
    {
        return this.Monuments.Sum(m =>
        {
            var monument = m as AirMonument;
            return monument.AirAffinity;
        });
    }

    public override string ToString()
    {
        return "Air Nation" + Environment.NewLine +  base.ToString();
    }
}

