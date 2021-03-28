using NUnit.Framework;
using System;
using System.Linq;
using ExtendedDatabase;

namespace Tests
{
    

    public class ExtendedDatabaseTests
    {
        private Person n1claren;
        private Person lyr1c;
        private ExtendedDatabase.ExtendedDatabase database;

        private int expectedResult;


        [SetUp]
        public void Setup()
        {
            n1claren = new Person(88888888, "n1claren");
            lyr1c = new Person(7777777, "lyr1c");
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void DatabaseCountTest()
        {
            int expectedResult = 1;

            database.Add(n1claren);

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseAddPersonWithSameUsername_Should_ThrowException()
        {
            database.Add(n1claren);

            var doppelganger = new Person(12345678, "n1claren");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(doppelganger);
            });

        }

        [Test]
        public void DatabaseAddPersonWithSameID_Should_ThrowException()
        {
            database.Add(n1claren);

            var IDstealer = new Person(88888888, "ID_Stealer_XXX_Nai_Dobroto_Makashi");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(IDstealer);
            });
        }

        [Test]
        public void AddWhenLimitIsReached_Should_ThrowException()
        {
            for (int i = 1; i <= 16; i++)
            {
                database.Add(new Person(i + 1, $"{i}Person{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(n1claren);
            });
        }

        [Test]
        public void RemoveWhenDatabaseIsEmpty_Should_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }


        [Test]
        public void Remove_Should_DecreaseCount()
        {
            database.Add(n1claren);

            int expectedCount = 0;

            database.Remove();

            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FindByNameUnableToFindPerson_Should_ThrowException()
        {
            database.Add(n1claren);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person somebody = database.FindByUsername("lyr1c");
            });
        }

        [Test]
        public void FindByUsername_Should_Throw_Exception_If_Parameter_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsername_Should_ReturnPerson()
        {
            database.Add(n1claren);

            var person = database.FindByUsername("n1claren");

            Assert.AreEqual(person.GetType(), n1claren.GetType());
        }

        [Test]
        public void FindByUsername_Should_BeCaseSensitive()
        {
            database.Add(lyr1c);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("LYR1C");
            });
        }

        [Test]
        public void FindByIDUnableToFindID_Should_ThrowException()
        {
            database.Add(n1claren);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person somebody = database.FindById(1020304050);
            });
        }

        [Test]
        public void FindByIDInputNegative_Should_ThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person person = database.FindById(-1020304050);
            });
        }


        [Test]
        public void FindByID_Should_ReturnPerson()
        {
            database.Add(n1claren);

            var person = database.FindById(88888888);

            Assert.AreEqual(person.GetType(), n1claren.GetType());
        }
    }
}