public class CommonItem
    : IItem
{
    private string name;
    private int strengthBonus;
    private int agilityBonus;
    private int intelligenceBonus;
    private int hitPointsBonus;
    private int damageBous;

    public CommonItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int StrengthBonus
    {
        get { return this.strengthBonus; }
        private set { this.strengthBonus = value; }
    }

    public int AgilityBonus
    {
        get { return this.agilityBonus; }
        private set { this.agilityBonus = value; }
    }

    public int IntelligenceBonus
    {
        get { return this.intelligenceBonus; }
        private set { this.intelligenceBonus = value; }
    }

    public int HitPointsBonus
    {
        get { return this.hitPointsBonus; }
        private set { this.hitPointsBonus = value; }
    }

    public int DamageBonus
    {
        get { return this.damageBous; }
        private set { this.damageBous = value; }
    }
}

