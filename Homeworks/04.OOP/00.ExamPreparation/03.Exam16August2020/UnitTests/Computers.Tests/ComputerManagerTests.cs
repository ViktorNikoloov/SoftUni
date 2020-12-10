using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsComputerConstructor()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            Assert.AreEqual("Apple", comp.Manufacturer);
            Assert.AreEqual("MacBook", comp.Model);
            Assert.AreEqual(1500.50M, comp.Price);
        }

        [Test]
        public void IsComputerManagerConstructor()
        {
            ComputerManager manager = new ComputerManager();
            List<Computer> expectedResult = new List<Computer>();
            Assert.AreEqual(0, manager.Count);
            Assert.AreEqual(expectedResult, manager.Computers);
            Assert.AreEqual(0, manager.Computers.Count);

        }

        [Test]
        public void IsAddedCompIsNull_Should()
        {
            Computer comp = null;
            ComputerManager manager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(comp));
        }

        [Test]
        public void IsAddedCompIsExist_Should()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(comp));
        }

        [Test]
        public void AddComputerMethod_Should()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.AreEqual(comp, manager.Computers.First(x => x.Manufacturer == "Apple" && x.Model == "MacBook"));
        }

        [Test]
        public void IsAddComputerChangeCount()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void IsRemoveComputerReturnCorrectComp()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.AreEqual(comp, manager.RemoveComputer("Apple", "MacBook"));
        }

        [Test]
        public void IsRemoveComputerChangeCount()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            Computer comp1 = new Computer("Apple1", "MacBook1", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);
            manager.AddComputer(comp1);
            manager.RemoveComputer("Apple", "MacBook");

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void GetComputerManufacturerCanNotBeNull()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);


            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "MacBook"));
        }

        [Test]
        public void GetComputerModelCanNotBeNull()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);


            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("Apple", null));
        }

        [Test]
        public void IsInGetComputerItemWeLookedForDoesNotExist()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.Throws<ArgumentException>(() => manager.GetComputer("Apple12", "MacBook15"));
        }

        [Test]
        public void IsGetComputerMethodReturnsCorrectComp()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);


            Assert.AreEqual(comp, manager.GetComputer("Apple", "MacBook"));
        }

        [Test]
        public void GetComputersByManufacturerCanNotBeNull()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            string man = null;

            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(man));
        }

        [Test]
        public void IsGetComputersByManufacturerReturnsCorrectComp()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            Computer comp1 = new Computer("Apple", "MacBook1", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);
            manager.AddComputer(comp1);

            List<Computer> expectedResult = new List<Computer>();
            expectedResult.Add(comp);
            expectedResult.Add(comp1);

             
            Assert.AreEqual(expectedResult, manager.GetComputersByManufacturer("Apple"));
        }

        [Test]
        public void IsComputerPropReturn()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            Computer comp1 = new Computer("Apple", "MacBook1", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);
            manager.AddComputer(comp1);

            List<Computer> expectedResult = new List<Computer>();
            expectedResult.Add(comp);
            expectedResult.Add(comp1);

            var actualResult = manager.Computers;
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
