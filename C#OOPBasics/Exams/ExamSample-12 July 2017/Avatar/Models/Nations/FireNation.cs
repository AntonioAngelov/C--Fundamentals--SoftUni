using System;
using System.Linq;

public class FireNation : Nation
{
    public override int GetBonusPercentage()
    {
        return this.Monuments.Sum(m =>
        {
            var monument = m as FireMonument;
            return monument.FireAffinity;
        });
    }

    public override string ToString()
    {
        return "Fire Nation" + Environment.NewLine + base.ToString();
    }
}

