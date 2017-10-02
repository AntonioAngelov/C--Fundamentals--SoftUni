public class Assassin
    : AbstractHero
{
    public const int assasinStrength = 25;
    public const int assasinAgility = 100;
    public const int assasinIntellience = 15;
    public const int assasinHitPoints = 150;
    public const int assasinDamage = 300;

    public Assassin(string name) 
        : base(name, assasinStrength,
            assasinAgility, assasinIntellience,
            assasinHitPoints, assasinDamage)
    {
    }
}


