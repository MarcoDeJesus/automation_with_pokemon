using NUnit.Framework;
using StatsManagement;
using System.Collections.Generic;

namespace AutomationATDD
{
    public class PokemonIVManagement
    {
        [Test]
        public void GenerateRandomIVValues_HP()
        {
            IVManagement ivObject = new IVManagement();
            int hp = ivObject.hp;
            Assert.That(hp, Is.GreaterThanOrEqualTo(-1));
            Assert.That(hp, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.hpRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_Attack()
        {
            IVManagement ivObject = new IVManagement();
            int attack = ivObject.attack;
            Assert.That(attack, Is.GreaterThanOrEqualTo(-1));
            Assert.That(attack, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.attackRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_Defense()
        {
            IVManagement ivObject = new IVManagement();
            int defense = ivObject.defense;
            Assert.That(defense, Is.GreaterThanOrEqualTo(-1));
            Assert.That(defense, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.defenseRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_SpecialAttack()
        {
            IVManagement ivObject = new IVManagement();
            int specialAttack = ivObject.specialAttack;
            Assert.That(specialAttack, Is.GreaterThanOrEqualTo(-1));
            Assert.That(specialAttack, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.specialAttackRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_SpecialDefense()
        {
            IVManagement ivObject = new IVManagement();
            int specialDefense = ivObject.specialDefense;
            Assert.That(specialDefense, Is.GreaterThanOrEqualTo(-1));
            Assert.That(specialDefense, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.specialDefenseRandom, true);
        }

        [Test]
        public void GenerateRandomIVValues_Speed()
        {
            IVManagement ivObject = new IVManagement();
            int speed = ivObject.speed;
            Assert.That(speed, Is.GreaterThanOrEqualTo(-1));
            Assert.That(speed, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.speedRandom, true);
        }

        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_HP_Randomnization(int hp, bool isRandom)
        {
            List<int> listIVs = new List<int> { hp, 1, 1, 1, 1, 1 };
            IVManagement ivObject = new IVManagement(listIVs);
            int actualHP = ivObject.hp;
            Assert.That(actualHP, Is.GreaterThanOrEqualTo(-1));
            Assert.That(actualHP, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.speedRandom, isRandom);
        }

        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(30, false)]
        [TestCase(31, false)]
        [TestCase(32, true)]
        public void TestingContructorWithListOfValues_Attack_Randomnization(int att, bool isRandom)
        {
            List<int> listIVs = new List<int> { 1, att, 1, 1, 1, 1 };
            IVManagement ivObject = new IVManagement(listIVs);
            int actualAttack = ivObject.attack;
            Assert.That(actualAttack, Is.GreaterThanOrEqualTo(-1));
            Assert.That(actualAttack, Is.LessThanOrEqualTo(31));
            Assert.AreEqual(ivObject.attackRandom, isRandom);
        }


    }
}
