using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 20, 50, 49)]
    [TestCase(50, 50, 10, 100, 99)]

    public void Weapon_Should_Lose_Durability_After_Attack(
        int health,
        int exp,
        int attack,
        int durability,
        int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);

        //Act
        axe.Attack(dummy);

        //Assert
        int actualResult = axe.DurabilityPoints;

        Assert.AreEqual(actualResult, expectedResult);
    }

    [Test]
    [TestCase(100, 100, 100, 0)]
    [TestCase(100, 100, 100, -15)]
    public void Attacking_With_Broken_Weapon_Should_Throw_Invalid_Operation_Exception(
        int health,
        int exp,
        int attack,
        int durability)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);

        //Act - Assert
        Assert.Catch<InvalidOperationException>(() => axe.Attack(dummy));
    }
}