using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 10;
    private const int AxeDurability = 10;
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;
    private IWeapon axe;
    private ITarget dummy;

    [SetUp]
    public void TestsInit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        //Act
        axe.Attack(this.dummy);

        //Assert
        Assert.AreEqual(9, this.axe.DurabilityPoints, "Axe Durability doesn't change after attack");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        //Arrange
        Axe axe = new Axe(1, 1);

        //Act
        axe.Attack(dummy);
        var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(this.dummy));

        //Assert
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }


}
