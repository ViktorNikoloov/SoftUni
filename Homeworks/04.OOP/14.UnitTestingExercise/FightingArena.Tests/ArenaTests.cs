using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior warrior;
        private Warrior barbarian;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 50, 100);
            barbarian = new Warrior("Stoyan", 100, 100);
            arena = new Arena();
        }

        [Test]
        [TestCase(1)]
        public void Enroll_Command_Should_Add_Warrior(int expectedCountResult)
        {
            //Arrange - Act
            arena.Enroll(warrior);

            //Assert
            int actualCountResult = arena.Count;

            Assert.AreEqual(actualCountResult, expectedCountResult);

        }

        [Test]
        public void Already_Enrolled_Warriors_Should_Not_Be_Able_To_Enroll_Again_And_Should_Throw_Invalid_Operation_Exception()
        {
            //Arrange - Act
            arena.Enroll(warrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));

        }

        [Test]
        [TestCase("Stoyan")]
        public void If_One_Of_The_Warriors_Is_Not_Enrolled_And_Is_Null_Should_Throw_Invalid_Operation_Exception(string anotherWarriorName)
        {
            //Arrange - Act
            arena.Enroll(warrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, anotherWarriorName));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(anotherWarriorName, warrior.Name));

        }

        [Test]
        [TestCase("Stoyan")]
        public void If_Bought_Warriors_Are_Enrolled_Atacker_Must_Atack_Defender(string anotherWarriorName)
        {
            //Arrange - Act
            arena.Enroll(warrior);
            arena.Enroll(barbarian);

            int expectedResult = barbarian.HP - warrior.Damage;
            arena.Fight("Pesho", "Stoyan");

            //Assert
            int actualResult = barbarian.HP;
            Assert.AreEqual(actualResult, expectedResult);

        }

    }
}
