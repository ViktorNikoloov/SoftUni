using System;
using System.Linq;

using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        // You must remove all namespaces "Database." in front of Database class before Judge ! 
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Be_Initialized_With_16_Elements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            int expectedResult = 16;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void Add_Operation_Should_Add_Element_At_The_Next_Cell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 15).ToArray();

            Database.Database database = new Database.Database(numbers);
            //Act 
            database.Add(5);

            //Assert
            int expectedCountResult = 16;
            int actualCountResult = database.Count;

            Assert.AreEqual(actualCountResult, expectedCountResult);

            //int expectedResult = 5;
            //int actualResult = database.Fetch()[15];
            
            //Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_Operation_Should_Throw_Invalid_Operation_Exception_If_Add_More_Than_16_Element()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);


            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }

        [Test]
        public void Remove_Operation_Should_Removing_Element_At_The_Last_Index()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act 
            database.Remove();

            //Assert
            int expectedCountResult = 15;
            int actualCountResult = database.Count;

            Assert.AreEqual(actualCountResult, expectedCountResult);

            //int expectedResult = 15;
            //int actualResult = database.Fetch()[14];

            //Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_Operation_Should_Throw_Invalid_Operation_Exception_If_Try_To_Remove_Element_From_Empty_Databaset()
        {
            //Arrange
            Database.Database database = new Database.Database();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_Operation_Should_Return_Element_As_Array()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act 
            int[] returnedArray = database.Fetch();

            //Assert
            int[] expectedCountResult = {1, 2, 3, 4, 5};

            Assert.AreEqual(returnedArray, expectedCountResult);
        }
    }
}