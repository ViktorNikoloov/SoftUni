using System;

using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        private Person person;

        [SetUp]
        public void Setup()
        {
            person = new Person(100000000L, "Ivan");
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        //Constructor Initialized tests cases
        [Test]
        [TestCase(1000000L, "Ivan")]
        [TestCase(665646846546565480L, "Vasil Ivanov")]

        public void Person_Constructor_Should_Be_Initialized(long id, string userName)
        {
            //Arrange
            person = new Person(id, userName);

            //Act - Assert
            long actualId = person.Id;
            string actualUserName = person.UserName;

            Assert.AreEqual(id, actualId);
            Assert.AreEqual(userName, actualUserName);
        }

        [Test]
        public void ExtendedDatabase_Constructor_Should_Throw_Argument_Exception_If_Array_Is_More_Than_16_Elements()
        {
            //Arrange
            Person[] people = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(100000000000L + i, "Ivan" + i);
            }

            //Act - Assert

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void ExtendedDatabase_Count_Should_Be_The_Same_As_Added_Array()
        {
            //Arrange
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                people[i] = new Person(100000000000L + i, "Ivan" + i);
            }

            //Act 
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            //Assert
            int expectedResult = people.Length;
            int actualCountResult = extendedDatabase.Count;

            Assert.AreEqual(expectedResult, actualCountResult);
        }


        //Add action tests cases
        [Test]
        [TestCase(30000651L, "Ivan")]
        public void Add_Should_Throw_Invalid_Operation_Exception_If_Array_Is_More_Than_16_Elements(
            long personId,
            string personUsername)
        {
            //Arrange
            for (int i = 0; i < 16; i++)
            {
                person = new Person(1000000000000L + i, "Ivan" + i);
                extendedDatabase.Add(person);
            }

            //Act
            Person anotherPerson = new Person(personId, personUsername);

            //Assert
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(anotherPerson));

        }

        [Test]
        [TestCase(30000651L, "Ivan", 3123131313L)]

        public void Add_Should_Throw_Invalid_Operation_Exception_If_There_Are_Already_Users_With_This_Username(
            long personId,
            string personUsername,
            long secondPersonId)
        {
            //Arrange
            person = new Person(personId, personUsername);
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            //Act
            Person secondPerson = new Person(secondPersonId, personUsername);

            //Assert
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(secondPerson));

        }

        [Test]
        [TestCase(30000651L, "Ivan", "Boris")]

        public void Add_Should_Throw_Invalid_Operation_Exception_If_There_Are_Already_Users_With_This_Id(
            long personId,
            string personUsername,
            string secondPersonUsername)
        {
            //Arrange
            person = new Person(personId, personUsername);
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            //Act
            Person secondPerson = new Person(personId, secondPersonUsername);

            //Assert

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(secondPerson));

        }

        //Remove action test cases

        [Test]
        public void Remove_Should_Throw_Invalid_Operation_Exception_If_Array_Is_Empty()
        {
            //Arrange
            //Act -Assert
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        [TestCase(1000000L, "Ivan", 665646846546565480L, "Vasil Ivanov", 1)]
        public void Remove_Operation_Should_Remove_One_Element_From_Array(
            long personId,
            string personUsername,
            long secondPersonId,
            string secondPersonUsername,
            int expectedResult)
        {
            //Arrange
            person = new Person(personId, personUsername);
            Person person1 = new Person(secondPersonId, secondPersonUsername);

            //Act
            extendedDatabase.Add(person);
            extendedDatabase.Add(person1);
            extendedDatabase.Remove();

            //Assert
            int actualResult = extendedDatabase.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }

        //FindByUsername action test cases

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void If_Username_Parameter_Is_Empty_Should_Throw_Argument_Null_Exception(string findUsername)
        {
            //Arrange
            extendedDatabase.Add(person);

            //Act - Assert
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(findUsername));
        }

        [Test]
        [TestCase("Vasil")]
        [TestCase("Stoyan")]
        [TestCase("Tanya")]
        public void If_No_User_Is_Present_By_This_Username_Should_Throw_Invalid_Operation_Exception(string findUsername)
        {
            //Arrange
            extendedDatabase.Add(person);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername(findUsername));
        }

        [Test]
        public void Find_By_Username_Should_Give_Back_The_Same_Person_We_Looked_For()
        {
            //Arrange
            extendedDatabase.Add(person);

            //Act 
            Person expectedResult = person;
            Person actualResult = extendedDatabase.FindByUsername("Ivan");

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}