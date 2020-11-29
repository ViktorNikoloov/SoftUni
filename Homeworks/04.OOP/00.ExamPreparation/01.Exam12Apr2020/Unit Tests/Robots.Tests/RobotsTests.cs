namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Ivaylo", 100);
        }

        [Test]
        [TestCase("Ivaylo", 100)]
        [TestCase("Viktor", 2500)]

        public void Robot_Constructor_Inicialized(
            string name,
            int maxBattery)
        {
            //Arrange - Act
            Robot robot = new Robot(
                name: name,
                maximumBattery: maxBattery);

            //Assert
            string nameActualResult = robot.Name;
            int maxBatteryActualResult = robot.MaximumBattery;
            int batteryActualResult = robot.Battery;

            Assert.AreEqual(nameActualResult, name);
            Assert.AreEqual(maxBatteryActualResult, maxBattery);
            Assert.AreEqual(batteryActualResult, maxBattery);

        }

        [Test]
        [TestCase(100, 0)]
        [TestCase(2500, 0)]

        public void Robot_Manager_Constructor_Inicialized(
            int capacity,
            int expectedCount)
        {
            //Arrange - Act
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Assert
            int capacityActualResult = robotManager.Capacity;
            int CountActualResult = robotManager.Count;

            Assert.AreEqual(capacityActualResult, capacity);
            Assert.AreEqual(CountActualResult, expectedCount);

        }

        [Test]
        [TestCase(-50)]
        [TestCase(-1)]

        public void If_Negative_Capacity_Is_Enter_Into_Robot_Manager_Constructor_Should_Throw_Argument_Exception(
            int capacity)
        {
            //Arrange - Act

            //Assert
            Assert.Throws<ArgumentException>(() => new RobotManager(
                capacity: capacity));

        }

        //Add cases
        [Test]
        [TestCase(10)]
        [TestCase(50)]

        public void If_Robot_We_Added_Already_Exist_Should_Throw_Invalid_Operation_Exception(
        int capacity)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Act
            robotManager.Add(robot);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        [TestCase(1)]

        public void If_Robot_Manager_Capacity_Is_Equal_To_Count_Should_Throw_Invalid_Operation_Exception(
        int capacity)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Act
            robotManager.Add(robot);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        [TestCase(10, 1)]

        public void If_Add_New_Robot_Count_Should_Increased_With_One(
        int capacity,
            int countExpectedResult)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Act
            robotManager.Add(robot);
            int robotManagerCount = robotManager.Count;

            //Assert
            Assert.AreEqual(robotManagerCount, countExpectedResult);
        }

        //Remove cases
        [Test]
        [TestCase(10, "Ivan")]

        public void If_Name_Into_Remove_Method_Is_Null_Should_Throw_Invalid_Operation_Exception(
        int capacity,
        string name)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Act
            robotManager.Add(robot);

            //Assert 
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(name));
        }

        //Work cases
        [Test]
        [TestCase(10, "Ivaylo", "Washer", 150)]

        public void If_Name_Into_Remove_Method_Is_Null_Should_Throw_Invalid_Operation_Exception(
        int capacity,
        string robotName,
        string job,
        int batteryUsage)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Act
            robotManager.Add(robot);

            //Assert 
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robotName, job, batteryUsage));
        }

        [Test]
        [TestCase(10, "Ivaylo", "Washer", 50, 50)]

        public void Work_Method_Should_Decreased_Robot_Battery_With_Battery_Usage(
        int capacity,
        string robotName,
        string job,
        int batteryUsage,
        int batteryExpectedResult)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Act
            robotManager.Add(robot);
            robotManager.Work(robotName, job, batteryUsage);

            //Assert 
            int batteryActualResult = robot.Battery;
            Assert.AreEqual(batteryActualResult, batteryExpectedResult);
        }

        //Charge cases
        [Test]
        [TestCase(10, "Ivaylo", "Washer", 50, 100)]

        public void Charge_Method_Should_Set_Robot_Battery_To_Maximum_Battery(
        int capacity,
        string robotName,
        string job,
        int batteryUsage,
        int batteryExpectedResult)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(
                capacity: capacity);

            //Act
            robotManager.Add(robot);
            robotManager.Work(robotName, job, batteryUsage);
            robotManager.Charge(robotName);

            //Assert 
            int batteryActualResult = robot.Battery;
            Assert.AreEqual(batteryActualResult, batteryExpectedResult);
        }


    }
}
