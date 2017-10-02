using System;
using System.Linq;

public class EarthNation : Nation
{
    public override int GetBonusPercentage()
    {
        return this.Monuments.Sum(m =>
        {
            var monument = m as EarthMonument;
            return monument.EarthAffinity;
        });
    }

    public override string ToString()
    {
        return "Earth Nation" + Environment.NewLine + base.ToString();
    }
}

