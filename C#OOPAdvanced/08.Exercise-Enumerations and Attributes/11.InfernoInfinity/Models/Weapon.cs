using System;
using System.Linq;

[Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class Weapon
{
    public Weapon(string weaponType, string rarity, string name)
    {
        this.Name = name;
        this.WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), weaponType);
        this.Rarity = (Rarity) Enum.Parse(typeof(Rarity), rarity);
        
        this.InitializeStats();
    }

    public string Name { get; private set; }

    public WeaponType WeaponType { get; private set; }

    public int MinDamage { get; private set; }

    public int MaxDamage { get; private set; }

    public Gem[] Gems { get; set; }

    public Rarity Rarity { get; private set; }

    private void InitializeStats()
    {
        int rarityIndex = 1;

        if (this.Rarity == Rarity.Uncommon)
        {
            rarityIndex = 2;
        }
        else if (this.Rarity == Rarity.Rare)
        {
            rarityIndex = 3;
        }
        else if(this.Rarity == Rarity.Epic)
        {
            rarityIndex = 5;
        }


        if (this.WeaponType == WeaponType.Axe)
        {
            this.MinDamage = 5 * rarityIndex;
            this.MaxDamage = 10 * rarityIndex;
            this.Gems = new Gem[4];
        }
        else if(this.WeaponType == WeaponType.Sword)
        {
            this.MinDamage = 4 * rarityIndex;
            this.MaxDamage = 6 * rarityIndex;
            this.Gems = new Gem[3];
        }
        else // if its Knife
        {
            this.MinDamage = 3 * rarityIndex;
            this.MaxDamage = 4 * rarityIndex;
            this.Gems = new Gem[2];
        }
    }

    public void AddGem(Gem gem, int index)
    {
        if (index < 0 || index >= this.Gems.Length)
        {
            return;
        }

        this.Gems[index] = gem;
    }

    public void RemoveGem(int index)
    {
        if (index < 0 || index >= this.Gems.Length 
            || this.Gems[index] == null)
        {
            return;
        }

        this.Gems[index] = null;
    }

    public string GetFullInformation()
    {
        var strength = Gems.Where(g => g != null).Sum(g => g.BonusStrength);
        var agility = Gems.Where(g => g != null).Sum(g => g.BonusAgility);
        var vitality = Gems.Where(g => g != null).Sum(g => g.BonusVitality);

        var totalMinDamage = this.MinDamage + strength * 2 + agility;
        var totalMaxDamage = this.MaxDamage + strength * 3 + 4 * agility;

        return $"{this.Name}: {totalMinDamage}-{totalMaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }

    
}
