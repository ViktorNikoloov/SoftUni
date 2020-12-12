using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("Viktor", "123456", "A10")]

        public void Is_Added_Cell_Not_Exist_Should_Throw_Argument_Exception(
            string owner, 
            string id, 
            string cell)
        {
            //Arrange - Act
            Item item = new Item(
                owner: owner,
                itemId: id);

            BankVault bank = new BankVault();

            //Assert
            Assert.Throws<ArgumentException>(() => bank.AddItem(cell, item));

        }

        [Test]
        [TestCase("Viktor", "12345", "A1")]

        public void Is_Added_Item_Exist_Should_Throw_Argument_Exception(
            string owner, 
            string id, 
            string cell)
        {
            //Arrange
            Item item = new Item(
                owner: owner,
                itemId: id);

            BankVault bank = new BankVault();

            //Act
            bank.AddItem(cell, item);

            //Assert
            Assert.Throws<ArgumentException>(() => bank.AddItem(cell, item));
        }

        [Test]
        [TestCase("Viktor", "12345", "A2", "A1")]

        public void Is_Exist_Cell_With_The_Same_Item_Should_Throw_Argument_Exception(
            string owner, 
            string id, 
            string cell, 
            string secondCell)
        {
            //Arrange
            Item item = new Item(
                owner: owner,
                itemId: id);

            BankVault bank = new BankVault();

            //Act
            bank.AddItem(cell, item);

            //Assert
            Assert.Throws<InvalidOperationException>(() => bank.AddItem(secondCell, item));
        }

        [Test]
        [TestCase("Viktor", "12345", "A2")]

        public void Is_Add_Method_Workd_Properly(
            string owner, 
            string id, 
            string cell)
        {
            //Arrange
            Item item = new Item(
                owner: owner,
                itemId: id);

            BankVault bank = new BankVault();

            //Act
            bank.AddItem(cell, item);

            //Assert
            var expectedItem = bank.VaultCells[cell];

            Assert.AreEqual(item, expectedItem);
        }

        [Test]
        [TestCase("Viktor", "12345", "A2", "Viktor", "12345", "A10")]

        public void Is_Try_To_Removed_Not_Existed_Cell_Should_Throw_Argument_Exception(
            string owner, 
            string id, 
            string cell, 

            string ownerToRemove, 
            string idToRemove, 
            string cellToRemove)
        {
            //Arrange
            Item item = new Item(
                owner: owner,
                itemId: id);

            Item itemToBeRemove = new Item(
                owner: ownerToRemove,
                itemId: idToRemove);

            BankVault bank = new BankVault();

            //Act
            bank.AddItem(cell, item);

            //Assert
            Assert.Throws<ArgumentException>(() => bank.RemoveItem(cellToRemove, itemToBeRemove));
        }

        [Test]
        [TestCase("Viktor", "12345", "A2", "Viktor", "1212345", "A2")]

        public void Is_Try_To_Removed_Not_Existed_Item_Should_Throw_Argument_Exception(
            string owner,
            string id,
            string cell,

            string ownerToRemove,
            string idToRemove,
            string cellToRemove)
        {
            //Arrange
            Item item = new Item(
                owner: owner,
                itemId: id);

            Item itemToBeRemove = new Item(
                owner: ownerToRemove,
                itemId: idToRemove);

            BankVault bank = new BankVault();

            //Act
            bank.AddItem(cell, item);

            //Assert
            Assert.Throws<ArgumentException>(() => bank.RemoveItem(cell, itemToBeRemove));
        }

    }
}