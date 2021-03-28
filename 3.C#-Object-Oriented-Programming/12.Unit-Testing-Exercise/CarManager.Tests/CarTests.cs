using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Nissan", "GT-R", 10.8, 100);
        }

        [Test]
        public void TestEmtpyConstructor()
        {
            string expectedMake = "Nissan";
            string expectedModel = "GT-R";
            double expectedFuelConsumption = 10.8;
            double expectedFuelCapacity = 100;

            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NullOrEmptyMake_Should_ThrowException(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, "GT-R", 10.8, 100);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NullOrEmptyModel_Should_ThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Nissan", model, 10.8, 100);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void ZeroOrNegativeFuelConsumption_Should_ThrowException(double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Nissan", "GT-R", value, 100);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void ZeroOrNegativeFuelCapacity_Should_ThrowException(double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Nissan", "GT-R", 10.8, value);
            });
        }

        [Test]
        public void RefuelNegativeAmount_Should_ThrowException()
        {
            double refuelAmount = -12;

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(refuelAmount);
            });
        }

        [Test]
        public void CarRefuelsCorrectly()
        {
            double refuelAmount = 12;

            double expectedFuelAmount = car.FuelAmount + 12;

            car.Refuel(refuelAmount);

            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void Overrefuel_Should_ReturnFuelAmountAsMaxCapacity()
        {
            double refuelAmount = 1000;

            double expectedFuelAmount = car.FuelCapacity;

            car.Refuel(refuelAmount);

            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void ImpossibleDrive_Should_ThrowException()
        {
            double driveDistance = 100000;

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(driveDistance);
            });
        }

        [Test]
        public void DriveFuel_Should_Decrease()
        {
            double driveDistance = 5;

            car.Refuel(1000);

            double espectedFuelAmount = car.FuelAmount - (driveDistance / 100 * car.FuelConsumption);

            car.Drive(driveDistance);

            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(espectedFuelAmount, actualFuelAmount);
        }
    }
}