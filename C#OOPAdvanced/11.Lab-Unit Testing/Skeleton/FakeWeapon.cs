public class FakeWeapon : IWeapon
{
    public void Attack(ITarget target)
    {}

    public int AttackPoints => 1;
    public int DurabilityPoints => 1;
}

