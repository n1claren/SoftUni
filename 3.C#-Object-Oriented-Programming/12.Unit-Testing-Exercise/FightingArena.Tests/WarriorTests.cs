using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestConstructor()
        {
            string expectedName = "n1claren";
            int expectedDamage = 9999;
            int expectedHealth = 1200;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHealth);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHealth = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHealth, actualHealth);
        }

        [Test]
        public void NullName_Should_ThrowException()
        {
            string name = null;
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void EmptyName_Should_ThrowException()
        {
            string name = "";
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void WhitespaceName_Should_ThrowException()
        {
            string name = "      ";
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void ZeroDamage_Should_ThrowException()
        {
            string name = "n1claren";
            int damage = 0;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void NegativeDamage_Should_ThrowException()
        {
            string name = "n1claren";
            int damage = -10;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void NegativeHP_Should_ThrowException()
        {
            string name = "n1claren";
            int damage = 12;
            int hp = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemiesWhenHPLow_Should_ThrowException(int attackerHP)
        {
            string attackerName = "n1claren";
            int attackerDmg = 10;

            string defenderName = "lyr1c";
            int defenderDmg = 10;
            int defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWithLowHP_Should_ThrowException(int defenderHP)
        {
            string attackerName = "n1claren";
            int attackerDamage = 10;
            int attackerHP = 100;

            string defenderName = "lyr1c";
            int defenderDamage = 10;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackingStrongerEnemy_Should_ThrowException()
        {
            string attackerName = "n1claren";
            int attackerDamage = 10;
            int attackerHP = 35;

            string defenderName = "lyr1c";
            int defenderDamage = 40;
            int defenderHP = 35;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void SuccessfulAttack_Should_DecreaseHP()
        {
            string attackerName = "n1claren";
            int attackerDamage = 10;
            int attackerHP = 40;

            string defenderName = "lyr1c";
            int defenderDamage = 5;
            int defenderHP = 50;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDamage;
            int expectedDefenderHP = defenderHP - attackerDamage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void TestKillingEnemyWithAttack()
        {
            string attackerName = "n1claren";
            int attackerDamage = 80;
            int attackerHealth = 100;

            string defenderName = "lyr1c";
            int defenderDamage = 10;
            int defenderHealth = 60;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHealth);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHealth);


            int expectedAttackerHP = attackerHealth - defenderDamage;
            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}