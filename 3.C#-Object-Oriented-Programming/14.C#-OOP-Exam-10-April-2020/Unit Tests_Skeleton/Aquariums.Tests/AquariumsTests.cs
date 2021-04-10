using NUnit.Framework;
using System;

namespace Aquariums.Tests
{
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish Nemo;
        private Fish NemosFather;

        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("Nemo's aquarium", 3);
            Nemo = new Fish("Nemo");
            NemosFather = new Fish("George");
        }

        [Test]
        public void ConstructorNullName_Should_Throw()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(null, 3);
            });
        }

        [Test]
        public void ConstructorNegativeCapacity_Should_Throw()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("TestAquarium", -1);
            });
        }

        [Test]
        public void TestConstructorInitialisation()
        {
            int expectedValue = 0;
            int actualValue = aquarium.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestConstructor()
        {
            string expectedName = "Nemo's aquarium";
            string actualName = aquarium.Name;

            int expectedCapacity = 3;
            int actualCapacity = aquarium.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void TestCounter()
        {
            aquarium.Add(Nemo);
            aquarium.Add(NemosFather);

            int expectedCount = 2;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestCapacity()
        {
            aquarium.Add(Nemo);
            aquarium.Add(NemosFather);
            aquarium.Add(new Fish("Nemo's Mother"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Nemo's girlfriend"));
            });
        }

        [Test]
        public void RemoveTest()
        {
            aquarium.Add(Nemo);
            aquarium.Add(NemosFather);

            aquarium.RemoveFish("George");

            int expectedCount = 1;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveNull_Should_Throw()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Nemo's girlfriend"));
                aquarium.RemoveFish("Nemo's boyfriend");
            });
        }

        [Test]
        public void SellingAFish_Should_MakeItUnavailable()
        {
            aquarium.Add(Nemo);
            aquarium.SellFish("Nemo");

            bool expectedResult = false;
            bool actualResult = Nemo.Available;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SelllingAFish_Should_ReturnFish()
        {
            aquarium.Add(Nemo);
            Fish soldFish = aquarium.SellFish(Nemo.Name);
            Assert.That(soldFish, Is.EqualTo(Nemo));
        }

        [Test]
        public void SellingNull_Should_Throw()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Nemo's girlfriend"));
                aquarium.SellFish("Nemo's boyfriend");
            });
        }

        [Test]
        public void TestReport()
        {
            aquarium.Add(Nemo);
            aquarium.Add(NemosFather);

            string expectedResult = "Fish available at Nemo's aquarium: Nemo, George";
            string actualResult = aquarium.Report();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddOverCapacity_Should_Throw()
        {
            aquarium = new Aquarium("useless Aquarium", 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(Nemo);
            });
        }


    }
}
