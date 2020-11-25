using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    [TestCase(100, 100, 50, 50)]
    [TestCase(50, 50, 30, 20)]

    public void Dummy_Should_Lose_Health_If_Attacked(
        int health, 
        int exp, 
        int attackPoints, 
        int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);

        //Act
        dummy.TakeAttack(attackPoints);

        //Assert
        int actualResult = dummy.Health;

        Assert.AreEqual(expectedResult, actualResult);


    }

    [Test]
    [TestCase(0, 50, 20)]
    [TestCase(-10, 50, 20)]

    public void Atacking_Dead_Dummy_Should_Throw_Invalid_Operation_Exception(
        int health,
        int exp,
        int attackPoints)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));


    }

    [Test]
    [TestCase(0, 10)]
    [TestCase(-6, 50)]

    public void Dead_Dummy_Should_Give_XP(
        int health,
        int exp)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);

        //Act
        int actualResult = dummy.GiveExperience();

        //Assert
        Assert.AreEqual(exp, actualResult);
    }

    [Test]
    [TestCase(50, 10)]
    [TestCase(25, 50)]

    public void Dead_Dummy_Should_Not_Give_XP(
        int health,
        int exp)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
