using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private Hero hero;
    private Mock<ITarget> mockTarget;
    private Mock<IWeapon> mockAxe;

    [SetUp]
    public void SetUp()
    {
        mockAxe = new Mock<IWeapon>();
       // mockAxe.Setup(a => a.AttackPoints).Returns(100);
        //mockAxe.Setup(d => d.DurabilityPoints).Returns(100);

        mockTarget = new Mock<ITarget>();
        mockTarget.Setup(e => e.GiveExperience()).Returns(20);
        mockTarget.Setup(d => d.IsDead()).Returns(true);

        hero = new Hero("Viktor", mockAxe.Object);
    }

    [Test]
    public void Hero_Should_Gives_XP_When_Target_Is_Dead()
    {
        hero.Attack(mockTarget.Object);

        Assert.AreEqual(20, hero.Experience);

    }
}