using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(0)]

        public void Is_Race_Entry_Constructor_Work_Properly(int expectedCountOfDic)
        {
            //Arrange - Act
            RaceEntry raceEntry = new RaceEntry();

            //Assert
            int actualCountOfDic = raceEntry.Counter;

            Assert.AreEqual(expectedCountOfDic, actualCountOfDic);
        }

        [Test]
        [TestCase("Seat", 1000, 2500.56, null)]

        public void Is_Name_Null_Should_Throw_Null_Argument_Exception(string model,int horsePower, double cubicCentimeters, string name)
        {
            //Arrange - Act
            UnitCar unitCar = new UnitCar(model, horsePower, cubicCentimeters);

            //Assert
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(name, unitCar));
        }


        [Test]

        public void Is_Driver_Null_Should_Throw_Invalid_Operation_Exception()
        {
            //Arrange - Act
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = null;

            //Assert
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        [TestCase("Seat", 1000, 2500.56, "Petyr")]

        public void Is_Driver_Exist_Should_Throw_Invalid_Operation_Exception(string model, int horsePower, double cubicCentimeters, string name)
        {
            //Arrange
            UnitCar unitCar = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver(name, unitCar);

            RaceEntry raceEntry = new RaceEntry();

            //Act
            raceEntry.AddDriver(unitDriver);

            //Assert
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver));
        }

        [Test]
        [TestCase("Seat", 1000, 2500.56, "Petyr", 1)]

        public void Dictionary_Count_Should_Increased_With_One_After_Add_Driver(string model, int horsePower, double cubicCentimeters, string name, int expectedResult)
        {
            //Arrange
            UnitCar unitCar = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver(name, unitCar);

            RaceEntry raceEntry = new RaceEntry();
            //Act
            raceEntry.AddDriver(unitDriver);

            //Assert
            Assert.AreEqual(expectedResult, raceEntry.Counter);
        }

        [Test]
        [TestCase("Seat", 1000, 2500.56, "Petyr")]


        public void Is_Return_Correct_String_After_Add_Driver(string model, int horsePower, double cubicCentimeters, string name)
        {
            //Arrange
            UnitCar unitCar = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver(name, unitCar);

            RaceEntry raceEntry = new RaceEntry();

            //Act
            string expectedMessage = $"Driver {name} added in race.";

            //Assert
            Assert.AreEqual(expectedMessage, raceEntry.AddDriver(unitDriver));
        }

        [Test]
        [TestCase("Seat", 1000, 2500.56, "Petyr")]

        public void Calculate_Average_Horse_Power_Should_Throw_Invalid_Operation_Exception_If_Driver_Count_Is_Below_Min(string model, int horsePower, double cubicCentimeters, string name)
        {
            //Arrange
            UnitCar unitCar = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver(name, unitCar);

            RaceEntry raceEntry = new RaceEntry();

            //Act
            raceEntry.AddDriver(unitDriver);

            //Assert
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        [TestCase(
            "Seat", 1000, 2500.56, 
            "BMW", 3000, 2500.56, 
            "VW", 6000, 2500.56,
            "Viktor", "Petyr", "Ivan"
            )]

        public void Is_Calculate_Average_Horse_Power_Returns_Correct_Result(
            string model, int horsePower, double cubicCentimeters, 
            string model1, int horsePower1, double cubicCentimeters1, 
            string model2, int horsePower2, double cubicCentimeters2, 
            string name, string name1, string name2)
        {
            //Arrange
            UnitCar unitCar = new UnitCar(model, horsePower, cubicCentimeters);
            UnitCar unitCar1 = new UnitCar(model1, horsePower1, cubicCentimeters1);
            UnitCar unitCar2 = new UnitCar(model2, horsePower2, cubicCentimeters2);

            UnitDriver unitDriver = new UnitDriver(name, unitCar);
            UnitDriver unitDriver1 = new UnitDriver(name1, unitCar1);
            UnitDriver unitDriver2 = new UnitDriver(name2, unitCar2);

            //Act
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriver1);
            raceEntry.AddDriver(unitDriver2);

            //Assert
            Double expectedResult = (double)(horsePower + horsePower1 + horsePower2) / 3;
            Assert.AreEqual(expectedResult, raceEntry.CalculateAverageHorsePower());
        }
    }
}