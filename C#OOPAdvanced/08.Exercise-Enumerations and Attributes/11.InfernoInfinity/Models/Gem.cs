using System;

public class Gem
{
    public Gem(string gemType, string clarity)
    {
        this.GemType = (GemType) Enum.Parse(typeof(GemType), gemType);
        this.Clarity = (Clarity) Enum.Parse(typeof(Clarity), clarity);

        this.InitializeStats();

    }

    public GemType GemType { get; private set; }

    public int BonusStrength { get; private set; }

    public int BonusAgility  { get; private set; }

    public int BonusVitality { get; private set; }

    public Clarity Clarity { get; private set; }

    private void InitializeStats()
    {
        if (this.GemType == GemType.Ruby)
        {
            this.BonusStrength = 7;
            this.BonusAgility = 2;
            this.BonusVitality = 5;
        }
        else if (this.GemType == GemType.Emerald)
        {
            this.BonusStrength = 1;
            this.BonusAgility = 4;
            this.BonusVitality = 9;
        }
        else // if amethyst
        {
            this.BonusStrength = 2;
            this.BonusAgility = 8;
            this.BonusVitality = 4;
        }

        this.BonusStrength += (int)this.Clarity;
        this.BonusAgility += (int)this.Clarity;
        this.BonusVitality += (int)this.Clarity;
    }
}

