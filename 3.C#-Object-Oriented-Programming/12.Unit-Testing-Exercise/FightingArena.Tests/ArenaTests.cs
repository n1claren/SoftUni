using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("n1claren", 50, 50);
            attacker = new Warrior("lyr1c", 100, 100);
            defender = new Warrior("sh0x", 100, 100);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void TestEnroll_Should_AddWarrior()
        {
            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestEnroll_Should_IncreaseCount()
        {
            int expectedCount = 2;

            arena.Enroll(warrior);
            arena.Enroll(new Warrior("lyr1c", 5, 60));

            int actualCount = arena.Warriors.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestEnroll_DublicateWarrior_Should_ThrowException()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            });
        }

        [Test]
        public void TestEnroll_SameNameWarrior_Should_ThrowException()
        {
            warrior = new Warrior("n1claren", 28, 48);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior = new Warrior("n1claren", 12, 24);
                arena.Enroll(warrior);
            });
        }

        [Test]
        public void FightingWithMissingAttacker_Should_ThrowException()
        {
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, defender.Name);
            });
        }

        [Test]
        public void FightingWithMissingDefender_Should_ThrowException()
        {
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, defender.Name);
            });
        }

        [Test]
        public void FightingBetweenTwoWarriors()
        {
            int expectedAttackerHP = attacker.HP - defender.Damage;
            int expectedDefenderHP = defender.HP - attacker.Damage;

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedDefenderHP, defender.HP);
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
        }
    }
}
