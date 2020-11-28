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
        [TestCase("Viktor", 15, 30, "Nikolay", 15, 100)]
        [TestCase("Tanya", 15, 29, "Nikolay", 15, 100)]

        public void IF_Warrior_Attack_With_HP_Equal_Or_Below_Min_Atack_HP_Should_Throw_Invalid_Operation_Exception(
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
        [TestCase("Viktor", 15, 100, "Nikolay", 15, 30)]
        [TestCase("Tanya", 40, 150, "Mariya", 40, 29)]

        public void IF_Warrior_Attack_Another_Warrior_With_HP_Equal_Or_Below_Min_Atack_HP_Should_Throw_Invalid_Operation_Exception(
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
        [TestCase("Viktor", 15, 40, "Nikolay", 41, 100)]
        [TestCase("Tanya", 40, 80, "Mariya", 100, 200)]

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

        [Test]
        [TestCase("Viktor", 15, 80, "Nikolay", 31, 100)]
        [TestCase("Tanya", 40, 150, "Mariya", 100, 200)]

        public void IF_Warrior_HP_Is_More_Than_Another_Warrior_Damage_Should_Decreased_First_Warrior_HP_With_Second_Warrior_Damage(
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
            //Act
            warrior.Attack(barbarian);

            //Assert
            int expectedResult = warriorHp - barbarianDmg;
            int actualResult = warrior.HP;

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("Viktor", 60, 80, "Nikolay", 31, 59, 0)]
        [TestCase("Tanya", 100, 150, "Mariya", 100, 40, 0)]

        public void IF_Warrior_Damage_Is_More_Than_Another_Warrior_HP_Should_Set_Another_Warrior_HP_To_Zero(
            string warriorName,
            int warriorDmg,
            int warriorHp,

            string barbarianName,
            int barbarianDmg,
            int barbarianHp,
            int expectedResult)
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
            //Act
            warrior.Attack(barbarian);

            //Assert
            int actualResult = barbarian.HP;

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("Viktor", 60, 80, "Nikolay", 31, 100)]
        [TestCase("Tanya", 100, 150, "Mariya", 100, 200)]

        public void IF_Warrior_Damage_Is_Less_Than_Another_Warrior_HP_Should_Decreased_Another_Warrior_HP_With_First_Warrior_Damage(
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
            //Act
            warrior.Attack(barbarian);

            //Assert
            int expectedResult = barbarianHp - warriorDmg;
            int actualResult = barbarian.HP;

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}