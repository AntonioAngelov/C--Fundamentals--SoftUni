using System;
using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int DummyHealth = 10;
    private const int DummyXp = 10;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.dummy = new Dummy(DummyHealth, DummyXp);
    }

    [Test]
    public void DummyLosesHealthIfAtacked()
    {
        //Act
        this.dummy.TakeAttack(5);

        //Assert
        Assert.AreEqual(5, this.dummy.Health, "Dummy health doest change after takig atack.");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        //Act
        this.dummy.TakeAttack(10);
        var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(1));

        //Assert
        Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyGivesXp()
    {
        //Act
        this.dummy.TakeAttack(DummyHealth);
        var xp = this.dummy.GiveExperience();

        //Assert
        Assert.AreEqual(10, xp, "Dead dummy must give experience.");
    }

    [Test]
    public void AliveDummyDoesntGiveXp()
    {
        //Act
        var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
    }
}
