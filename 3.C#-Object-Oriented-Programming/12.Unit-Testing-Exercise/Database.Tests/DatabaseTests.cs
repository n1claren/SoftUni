using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            database = new Database.Database(initialData);
        }

        [Test]
        public void TestConstructor()
        {
            int[] data = new int[] { 1, 2, 3 };
            database = new Database.Database(data);

            int expectedCount = 3;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Constructor_Should_ThrowException_WithBiggerCollection()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database.Database(data);
            });
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            database.Add(1);

            int expectedCount = 3;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            int expectedCount = 1;

            database.Remove();

            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowWhenDatabaseIsEmpty()
        {
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            database = new Database.Database(expectedData);

            int[] actualData = database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

    }
}