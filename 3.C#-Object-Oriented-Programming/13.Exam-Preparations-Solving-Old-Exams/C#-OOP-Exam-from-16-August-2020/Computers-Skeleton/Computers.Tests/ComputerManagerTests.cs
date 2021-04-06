using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private ComputerManager cm;
        private Computer twoThousand;
        private Computer threeThousand;
        private Computer fourThousand;

        [SetUp]
        public void Setup()
        {
            cm = new ComputerManager();

            twoThousand = new Computer("Asus", "ROG2000", 2000);
            threeThousand = new Computer("Asus", "ROG3000", 3000);
            fourThousand = new Computer("Asus", "ROG4000", 4000);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(cm.Computers);
            Assert.AreEqual(0, cm.Computers.Count);

            Assert.AreEqual("Asus", twoThousand.Manufacturer);
            Assert.AreEqual("ROG2000", twoThousand.Model);
            Assert.AreEqual(2000, twoThousand.Price);
        }

        [Test]
        public void Count_Should_ReturnCount()
        {
            cm.AddComputer(twoThousand);
            cm.AddComputer(threeThousand);
            cm.AddComputer(fourThousand);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, cm.Count);
        }

        [Test]
        public void AddComputer_Should_Add()
        {
            cm.AddComputer(twoThousand);

            Assert.AreEqual(1, cm.Computers.Count);
        }

        [Test]
        public void AddingSameComputer_Should_Throw()
        {
            cm.AddComputer(twoThousand);

            Assert.Throws<ArgumentException>(() =>
            {
                cm.AddComputer(twoThousand);
            });
        }

        [Test]
        public void RemoveComputer_Should_Remove()
        {
            cm.AddComputer(twoThousand);
            cm.AddComputer(threeThousand);

            cm.RemoveComputer("Asus", "ROG2000");
            cm.RemoveComputer("Asus", "ROG3000");

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, cm.Count);
        }

        [Test]
        public void RemoveComputer_Should_ReturnRemovedComputer()
        {
            cm.AddComputer(twoThousand);

            Computer testComputer = twoThousand;
            Computer removedComputer = cm.RemoveComputer("Asus", "ROG2000");

            Assert.AreEqual(testComputer.Manufacturer, removedComputer.Manufacturer);
            Assert.AreEqual(testComputer.Model, removedComputer.Model);
            Assert.AreEqual(testComputer.Price, removedComputer.Price);
        }

        [Test]
        public void AddComputer_Should_Throw_NullValueAdd()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                cm.AddComputer(null);
            });
        }

        [Test]
        public void GetComputer_Should_ReturnComputer()
        {
            cm.AddComputer(twoThousand);
            cm.AddComputer(threeThousand);
            cm.AddComputer(fourThousand);

            Computer testComputer = twoThousand;
            Computer returnedComputer = cm.GetComputer("Asus", "ROG2000");

            Assert.AreEqual(testComputer.Manufacturer, returnedComputer.Manufacturer);
            Assert.AreEqual(testComputer.Model, returnedComputer.Model);
            Assert.AreEqual(testComputer.Price, returnedComputer.Price);
        }

        [Test]
        public void GetComputer_NullManufacturer_Should_Throw()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                cm.GetComputer(null, "ROG2000");
            });
        }

        [Test]
        public void GetComputer_NullModel_Should_Throw()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                cm.GetComputer("Asus", null);
            });
        }

        [Test]
        public void GetComputer_Should_Throw_IfComputerDoesNotExist()
        {
            cm.AddComputer(twoThousand);
            cm.AddComputer(threeThousand);
            cm.AddComputer(fourThousand);

            Assert.Throws<ArgumentException>(() =>
            {
                cm.GetComputer("Samsung", "iComputer");
            });
        }

        [Test]
        public void GetGetComputersByManufacturer_Should_Throw_NullValue()
        {
            cm.AddComputer(twoThousand);
            cm.AddComputer(threeThousand);
            cm.AddComputer(fourThousand);

            Assert.Throws<ArgumentNullException>(() => 
            {
                cm.GetComputersByManufacturer(null);
            });
        }

        [Test]
        public void GetGetComputersByManufacturer_Should_ReturnCollection()
        {
            Computer computer = new Computer("Samsung", "iComputer", 7777);

            cm.AddComputer(computer);
            cm.AddComputer(twoThousand);
            cm.AddComputer(threeThousand);
            cm.AddComputer(fourThousand);

            ICollection<Computer> computersReturn = cm.GetComputersByManufacturer("Asus");
            ICollection<Computer> computers = 
                new List<Computer>() { twoThousand, threeThousand, fourThousand };

            Assert.AreEqual(3, computersReturn.Count);

            CollectionAssert.AreEqual(computersReturn, computers);
        }

        [Test]
        public void RemovingNonExistingComputer_Should_Throw()
        {
            cm.AddComputer(twoThousand);

            Assert.Throws<ArgumentException>(() =>
            {
                cm.RemoveComputer("Samsung", "iComputer");
            });
        }

    }
}