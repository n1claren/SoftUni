using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        RaceEntry raceEntry;
        UnitDriver driver;
        UnitCar car;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();

            car = new UnitCar("Nissan GT-R", 600, 3800);
            driver = new UnitDriver("n1claren", car);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(raceEntry);
            Assert.AreEqual(0, raceEntry.Counter);
            Assert.AreEqual("Nissan GT-R", car.Model);
            Assert.AreEqual("Nissan GT-R", driver.Car.Model);
        }

        [Test]
        public void TestCounter()
        {
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(new UnitDriver("Boiko Borisov", new UnitCar("Lada", 45, 1400)));

            Assert.AreEqual(2, raceEntry.Counter);
        }

        [Test]
        public void AddDriver_AddingNull_Should_Throw()
        {
            Assert.Throws<InvalidOperationException>(() => { raceEntry.AddDriver(null); });
        }

        [Test]
        public void AddSameDriver_Should_Throw()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => { raceEntry.AddDriver(driver); });
        }

        [Test]
        public void AddDriver_Should_ReturnCorrectString()
        {
            string result = raceEntry.AddDriver(driver);

            string expectedResult = string.Format("Driver {0} added in race.", driver.Name);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void CalculateAvgHP_Should_Throw_IfParticipantsAreLessThanTwo()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => { raceEntry.CalculateAverageHorsePower(); });
        }

        [Test]
        public void CalculateAvgHP_Should_ReturnCorrectDouble()
        {
            double expectedResult = 5.5;

            raceEntry.AddDriver(new UnitDriver("Boiko Borisov", new UnitCar("Wagon", 1, 1500)));
            raceEntry.AddDriver(new UnitDriver("Slavi Trifonov", new UnitCar("Carriage", 10, 3000)));

            double actualResult = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestOne()
        {
            
        }
    }
}