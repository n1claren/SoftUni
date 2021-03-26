using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }

    [Test]
    public void When_AxeAttackAndDurabilityAreProvided_SouldSetCorrectly()
    {
        Assert.AreEqual(axe.DurabilityPoints, durability);
        Assert.AreEqual(axe.AttackPoints, attack);
    }

    [Test]
    public void When_AxeAttacks_ShouldLoseDurability()
    {
        axe.Attack(dummy);

        Assert.AreEqual(axe.DurabilityPoints, durability - 1);
    }

    [Test]
    public void When_AxeAttacksWithDurabilityPointsZero_ShouldThrowException()
    {
        dummy = new Dummy(999, 999);

        Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        });
    }

    [Test]
    public void When_AxeAttackIsCalledWithNull_ShouldThrowNullRef()
    {
        Assert.Throws<NullReferenceException>(() =>
        {
            axe.Attack(null);
        });
    }

}