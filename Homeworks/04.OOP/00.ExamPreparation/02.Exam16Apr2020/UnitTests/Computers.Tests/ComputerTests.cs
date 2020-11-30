namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        private Part part;
        [SetUp]
        public void Setup()
        {
            part = new Part("VideoCard", 180.98888888M);
        }

        //Constructors test
        [Test]
        [TestCase("VideoCard", 180.98888888)]
        public void Part_constructor_Initialized(string expectedName, decimal expectedPrice)
        {
            //Avarrage - Act

            //Assert
            string nameActualResult = part.Name;
            decimal priceActualResult = part.Price;

            Assert.AreEqual(nameActualResult, expectedName);
            Assert.AreEqual(priceActualResult, expectedPrice);
        }

        [Test]
        [TestCase("Viktor's computer", 0)]
        [TestCase("Ivaylo's computer", 0)]

        public void Computer_Constructor_Initialized(string name, int countExpectedResult)
        {
            //Avarrage - Act
            Computer computer = new Computer(
                name: name);

            //Assert
            string nameActualResult = computer.Name;
            int countActualResult = computer.Parts.Count;

            Assert.AreEqual(nameActualResult, name);
            Assert.AreEqual(countActualResult, countExpectedResult);
        }

        //Name case
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("       ")]

        public void If_Name_Is_Empty_Or_Null_Or_WhiteSpace_Should_Throw_Argument_Null_Exception(string name)
        {
            //Avarrage 

            //Assert - act
            Assert.Throws<ArgumentNullException>(() => new Computer(
                name: name));
        }

        //TotalPrice case
        [Test]
        [TestCase("MotherBorder", 365.65789, "Viktor's computer")]
        [TestCase("Processor", 756.90, "Ivaylo's computer")]

        public void Total_Price_Should_Return_Sum_Of_All_Parts(string partName, decimal price, string computerName)
        {
            //Avarrage 
            Part secondPart = new Part(
                name: partName,
                price: price);

            Computer computer = new Computer(
                name: computerName);

            //Act
            computer.AddPart(part);
            computer.AddPart(secondPart);

            //Assert
            decimal expectedTotalPrice = part.Price + secondPart.Price;
            decimal actualTotalPrice = computer.TotalPrice;

            Assert.AreEqual(actualTotalPrice, expectedTotalPrice);

        }

        //Add case
        [Test]
        [TestCase("Viktor's computer", null)]

        public void If_Name_Of_The_Part_Into_Add_Is_Null_Should_Throw_Invalid_Operation_Exception(string computerName, Part part)
        {
            //Avarrage 
            Computer computer = new Computer(
                name: computerName);

            //Assert - Act
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(part));
        }

        //Remove case
        [Test]
        [TestCase("Viktor's computer", "MotherBorder", 365.65789, 1, null)]

        public void Remove_Should_Decreased_Count_With_One(string computerName, string partName, decimal price, int expectedCountResult, string expectedPartResult)
        {
            //Avarrage 
            Computer computer = new Computer(
                name: computerName);

            Part secondPart = new Part(
                name: partName,
                price: price);

            //Act
            computer.AddPart(part);
            computer.AddPart(secondPart);

            computer.RemovePart(secondPart);

            //Assert
            int actualCountResult = computer.Parts.Count;
            Part removedPart = computer.GetPart(partName);

            Assert.AreEqual(actualCountResult, expectedCountResult);
            Assert.AreEqual(removedPart, expectedPartResult);
        }

        //GetPart case
        [Test]
        [TestCase("Viktor's computer")]

        public void Get_Part_Should_Return_Part_We_Ask_for(string computerName)
        {
            //Avarrage 
            Computer computer = new Computer(
                name: computerName);

            //Act
            computer.AddPart(part);

            //Assert
            Part actualPartResult = computer.GetPart(part.Name);

            Assert.AreEqual(actualPartResult.Name, part.Name);
        }
    }
}