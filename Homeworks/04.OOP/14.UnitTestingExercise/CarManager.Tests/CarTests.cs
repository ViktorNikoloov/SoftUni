//using System;

using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("Seat", "Toledo", 10, 70)]

        public void Constructor_Should_Be_Initialized(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            string actualCarMake = car.Make;
            string actualCarModel = car.Model;
            double actualCarFuelConsumption = car.FuelConsumption;
            double actualCarFuelCapacity = car.FuelCapacity;

            //Assert
            Assert.AreEqual(make, actualCarMake);
            Assert.AreEqual(model, actualCarModel);
            Assert.AreEqual(fuelConsumption, actualCarFuelConsumption);
            Assert.AreEqual(fuelCapacity, actualCarFuelCapacity);

        }

        [Test]
        [TestCase("Seat", "Toledo", 10, 70, 0)]

        public void Constructor_Should_Set_Car_Amount_To_Zero(string make, string model, double fuelConsumption, double fuelCapacity, double expectedResult)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act - Assert
            double actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);


        }

        //Make test case
        [Test]
        [TestCase(null, "Toledo", 0, 50)]
        [TestCase("", "Toledo", -15, 70)]

        public void If_Make_Is_Null_Or_Empty_Should_Throw_Argument_Exception(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act - Assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }


        //Model test case
        [Test]
        [TestCase("Seat", null, 0, 50)]
        [TestCase("Seat", "", -15, 70)]

        public void If_Model_Is_Null_Or_Empty_Should_Throw_Argument_Exception(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act - Assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        //Fuel Consumption test case
        [Test]
        [TestCase("Seat", "Toledo", 0, 50)]
        [TestCase("Seat", "Toledo", -15, 70)]

        public void If_Fuel_Consumption_Is_Zero_Or_Negative_Should_Throw_Argument_Exception(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act - Assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        //Fuel Amount test case ???????????
        [Test]
        [TestCase("Seat", "Toledo", 20, 70, 1, 100)]
        [TestCase("Seat", "Toledo", 35, 70, 1, 50)]

        //public void If_Fuel_Amount_Is_Negative_Should_Throw_Argument_Exception(string make, string model, double fuelConsumption, double fuelCapacity, double FuelToRefuel, double distanceToDrive)
        //{
        //    //Arrange
        //    //Arrange
        //    car = new Car(make, model, fuelConsumption, fuelCapacity);

        //    //Act
        //    car.Refuel(FuelToRefuel);

        //    //Assert
        //    Assert.Throws<ArgumentException>(() => car.Drive(distanceToDrive));
        //}

        //Fuel capacity test case
        [Test]
        [TestCase("Seat", "Toledo", 10, 0)]
        [TestCase("Seat", "Toledo", 10, -15)]

        public void If_Fuel_Capacity_Is_Zero_Or_Negative_Should_Throw_Argument_Exception(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange

            //Act - Assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        //Refuel test cases
        [Test]
        [TestCase("Seat", "Toledo", 10, 70, 1.6)]
        [TestCase("Seat", "Toledo", 10, 70, 45)]

        public void Fuel_Amount_Geter_Should_Return_The_Added_Value(string make, string model, double fuelConsumption, double fuelCapacity, double refuel)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            car.Refuel(refuel);
            //DOTO: What if we Refuel twice ?
            double actualCarFuelAmountResult = car.FuelAmount;

            //Assert
            Assert.AreEqual(refuel, actualCarFuelAmountResult);
        }

        [Test]
        [TestCase("Seat", "Toledo", 10, 70, 0)]
        [TestCase("Seat", "Toledo", 10, 70, -10)]

        public void Is_Fuel_Amount_Is_Zero_Or_Negative_Shoud_Throw_Argument_Exception(string make, string model, double fuelConsumption, double fuelCapacity, double refuel)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act - Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(refuel));
        }

        [Test]
        [TestCase("Seat", "Toledo", 10, 30, 60)]
        [TestCase("Seat", "Toledo", 10, 55, 100)]

        public void If_Fuel_Amount_Is_Bigger_Than_Fuel_Capacity_Fuel_Amount_Should_Be_Equal_To_Fuel_Capacity(string make, string model, double fuelConsumption, double fuelCapacity, double refuel)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            car.Refuel(refuel);
            double actualCarFuelAmountResult = car.FuelAmount;

            //Assert
            Assert.AreEqual(fuelCapacity, actualCarFuelAmountResult);
        }

        //Drive test cases
        [Test]
        [TestCase("Seat", "Toledo", 5, 70, 30, 100)]
        [TestCase("Seat", "Toledo", 3, 70, 45, 50)]

        public void Drive_Should_Decreased_Fuel_Amount(string make, string model, double fuelConsumption, double fuelCapacity, double FuelToRefuel, double distanceToDrive)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            car.Refuel(FuelToRefuel);
            double carCurrFuelAmount = car.FuelAmount;

            car.Drive(distanceToDrive);

            //Assert
            double carDistanceFuelAmount = (distanceToDrive / 100) * fuelConsumption;

            double expectedCarFuelAmountResult = carCurrFuelAmount - carDistanceFuelAmount;
            double actualCarFuelAmountResult = car.FuelAmount;

            Assert.AreEqual(expectedCarFuelAmountResult, actualCarFuelAmountResult);
        }

        [Test]
        [TestCase("Seat", "Toledo", 10, 70, 30, 2000)]
        [TestCase("Seat", "Toledo", 15, 70, 45, 24000)]

        public void If_Fuel_Amount_Is_Not_Enough_For_The_Distance_Should_Throw_Invalid_Operation_Exception(string make, string model, double fuelConsumption, double fuelCapacity, double FuelToRefuel, double distanceToDrive)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            car.Refuel(FuelToRefuel);

            //Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distanceToDrive));
        }

    }
}