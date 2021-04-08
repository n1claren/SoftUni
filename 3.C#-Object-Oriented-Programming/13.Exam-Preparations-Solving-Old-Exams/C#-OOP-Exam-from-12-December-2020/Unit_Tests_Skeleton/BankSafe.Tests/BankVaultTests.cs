using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item smartphone;
        private Item keys;
        private Item smartWatch;
        private Item budgetSmartphone;
        private Item bmwKeys;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();

            smartphone = new Item("Nikolay Ivanov", "1");
            keys = new Item("Nikolay Ivanov", "2");
            smartWatch = new Item("Nikolay Ivanov", "3");

            budgetSmartphone = new Item("Kalin Yankov", "11");
            bmwKeys = new Item("Kalin Yankov", "22");
        }

        [Test]
        public void TestConstructor()
        {
            int expectedValue = 12;
            int actualValue = bankVault.VaultCells.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddingItemToNonExistingCell_Should_Throw()
        {
            Assert.Throws<ArgumentException>(() => 
            { 
                bankVault.AddItem("A12", keys); 
            });
        }

        [Test]
        public void AddingItemToTakenCell_Should_Throw()
        {
            bankVault.AddItem("A1", keys);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("A1", bmwKeys);
            });
        }

        [Test]
        public void AddingAlreadyAddedItem_Should_Throw()
        {
            bankVault.AddItem("A1", keys);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bankVault.AddItem("A2", keys);
            });
        }

        [Test]
        public void AddingItem_Should_ReturnCorrectString()
        {
            string expectedResult = $"Item:{keys.ItemId} saved successfully!";
            string actualResult = bankVault.AddItem("A1", keys);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddingItemTest()
        {
            bankVault.AddItem("A1", keys);

            string expectedID = keys.ItemId;
            string expectedOwner = keys.Owner;

            string actualID = bankVault.VaultCells["A1"].ItemId;
            string actualOwner = bankVault.VaultCells["A1"].Owner;

            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedOwner, actualOwner);
        }

        [Test]
        public void RemoveItemNonExistingCell_Should_Throw()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("A12", keys);
            });
        }

        [Test]
        public void RemoveWrongItem_Should_Throw()
        {
            bankVault.AddItem("A1", budgetSmartphone);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("A1", keys);
            });
        }

        [Test]
        public void RemoveItem_Should_ReturnCorrectString()
        {
            bankVault.AddItem("A1", bmwKeys);

            string expectedResult = $"Remove item:{bmwKeys.ItemId} successfully!";
            string actualResult = bankVault.RemoveItem("A1", bmwKeys);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveItemTest()
        {
            bankVault.AddItem("A1", bmwKeys);
            bankVault.RemoveItem("A1", bmwKeys);

            Assert.AreEqual(null, bankVault.VaultCells["A1"]);
        }
    }
}