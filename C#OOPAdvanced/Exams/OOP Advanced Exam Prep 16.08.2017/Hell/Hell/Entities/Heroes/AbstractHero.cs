using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public abstract class AbstractHero 
    : IHero, IComparable<IHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }
    
    public ICollection<IItem> Items
    {
        get
        {
            Type inventoryType = typeof(HeroInventory);
            FieldInfo itemsInfo = inventoryType.GetField("commonItems", BindingFlags.NonPublic | BindingFlags.Instance);

            Dictionary<string, IItem>  items = (Dictionary<string, IItem>)itemsInfo.GetValue(this.inventory);

            return items.Values;
        }
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public void AddItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public int CompareTo(IHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}");

        if (this.Items.Count == 0)
        {
            result.AppendLine("Items: None");
        }
        else
        {
            result.AppendLine("Items:");
        }

        foreach (var item in this.Items)
        {
            result.AppendLine($"###Item: {item.Name}")
                .AppendLine($"###+{item.StrengthBonus} Strength")
                .AppendLine($"###+{item.AgilityBonus} Agility")
                .AppendLine($"###+{item.IntelligenceBonus} Intelligence")
                .AppendLine($"###+{item.HitPointsBonus} HitPoints")
                .AppendLine($"###+{item.DamageBonus} Damage");
        }

        return result
            .ToString()
            .Trim();


    }
}