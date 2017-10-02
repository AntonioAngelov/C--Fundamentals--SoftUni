public class Barbarian
    : AbstractHero
{
    public const int barbarianStrength = 90;
    public const int barbarianAgility = 25;
    public const int brbarianIntellience = 10;
    public const int barbarianHitPoints = 350;
    public const int barbarianDamage = 150;


    public Barbarian(string name) 
        : base(name, barbarianStrength, 
            barbarianAgility, brbarianIntellience, 
            barbarianHitPoints, barbarianDamage)
    {
    }
}

