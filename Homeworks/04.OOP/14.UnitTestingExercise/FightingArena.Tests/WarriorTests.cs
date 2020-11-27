using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase("Viktor", 25, 100)]
        [TestCase("Tanya", 70, 250)]

        public void Warrior_Constructor_Initialized(
            string name, 
            int dmg, 
            int hp)
        {
            //Arrange - Act
            warrior = new Warrior(
                name: name,
                damage: dmg,
                hp: hp);

            //Assert
            string actualName = warrior.Name;
            int actualDmg = warrior.Damage;
            int actualHp = warrior.HP;

            Assert.AreEqual(actualName, name);
            Assert.AreEqual(actualDmg, dmg);
            Assert.AreEqual(actualHp, hp);


        }

        //Name case
        [Test]
        [TestCase(null, 25, 100)]
        [TestCase("", 70, 250)]
        [TestCase("      ", 25, 90)]

        public void IF_Warrior_Name_Is_Null_Or_Empty_Or_Whitespace_Should_Throw_Argument_Exception(
            string name,
            int dmg,
            int hp)
        {
            //Arrange 

            //Act - Assert

            Assert.Throws<ArgumentException>(()=> new Warrior(name, dmg, hp));
        }

        //Damage case
        [Test]
        [TestCase("Viktor", 0, 250)]
        [TestCase("Tanya", -10, 90)]

        public void IF_Warrior_Damage_Is_Zero_Or_Negative_Should_Throw_Argument_Exception(
            string name,
            int dmg,
            int hp)
        {
            //Arrange 

            //Act - Assert

            Assert.Throws<ArgumentException>(() => new Warrior(name, dmg, hp));
        }

        //HP case
        [Test]
        [TestCase("Tanya", 15, -18)]
        [TestCase("Viktor", 40, -1)]

        public void IF_Warrior_HP_Is_Negative_Should_Throw_Argument_Exception(
            string name,
            int dmg,
            int hp)
        {
            //Arrange 

            //Act - Assert

            Assert.Throws<ArgumentException>(() => new Warrior(name, dmg, hp));
        }

        //Attack cases
        [Test]
        [TestCase("Viktor", 15, 5, "Nikolay", 15, 100)]
        [TestCase("Tanya", 40, 29, "Mariya", 40, 100)]

        public void IF_Warrior_Attack_With_HP_Below_Min_Atack_HP_Should_Throw_Invalid_Operation_Exception(
            string warriorName,
            int warriorDmg,
            int warriorHp, 

            string barbarianName,
            int barbarianDmg,
            int barbarianHp)
        {
            //Arrange 
            warrior = new Warrior(
                name: warriorName,
                damage: warriorDmg,
                hp: warriorHp);

            Warrior barbarian = new Warrior(
                name: barbarianName,
                damage: barbarianDmg,
                hp: barbarianHp);
            //Act - Assert

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(barbarian));
        }

        [Test]
        [TestCase("Viktor", 15, 100, "Nikolay", 15, 29)]
        [TestCase("Tanya", 40, 150, "Mariya", 40, 5)]

        public void IF_Warrior_Attack_Another_Warrior_With_HP_Below_Min_Atack_HP_Should_Throw_Invalid_Operation_Exception(
            string warriorName,
            int warriorDmg,
            int warriorHp,

            string barbarianName,
            int barbarianDmg,
            int barbarianHp)
        {
            //Arrange 
            warrior = new Warrior(
                name: warriorName,
                damage: warriorDmg,
                hp: warriorHp);

            Warrior barbarian = new Warrior(
                name: barbarianName,
                damage: barbarianDmg,
                hp: barbarianHp);
            //Act - Assert

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(barbarian));
        }

        [Test]
        [TestCase("Viktor", 15, 30, "Nikolay", 31, 100)]
        [TestCase("Tanya", 40, 150, "Mariya", 100, 200)]

        public void IF_Warrior_HP_Is_Below_Another_Warrior_Damage_Should_Throw_Invalid_Operation_Exception(
            string warriorName,
            int warriorDmg,
            int warriorHp,

            string barbarianName,
            int barbarianDmg,
            int barbarianHp)
        {
            //Arrange 
            warrior = new Warrior(
                name: warriorName,
                damage: warriorDmg,
                hp: warriorHp);

            Warrior barbarian = new Warrior(
                name: barbarianName,
                damage: barbarianDmg,
                hp: barbarianHp);
            //Act - Assert

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(barbarian));
        }
    }
}