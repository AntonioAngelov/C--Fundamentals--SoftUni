using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const string HeroName = "Pesho";

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies()
    {
        //Arange
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero(HeroName, fakeWeapon.Object);
        //Act
        hero.Attack(fakeTarget.Object);

        // Asser
        Assert.AreEqual(20, hero.Experience, "Hero doesnt get experience.");

    }
}

