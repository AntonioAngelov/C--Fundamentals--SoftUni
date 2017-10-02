public class Wizard
    : AbstractHero
{
    public const int assasinStrength = 25;
    public const int assasinAgility = 25;
    public const int assasinIntellience = 100;
    public const int assasinHitPoints = 100;
    public const int assasinDamage = 250;

    public Wizard(string name)
        : base(name, assasinStrength,
            assasinAgility, assasinIntellience,
            assasinHitPoints, assasinDamage)
    {
    }
}

