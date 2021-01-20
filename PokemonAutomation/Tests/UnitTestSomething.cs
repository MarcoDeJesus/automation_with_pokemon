using Features;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAutomation.Tests
{   
    [TestFixture]
    public class UnitTestSomething
    {
        [Test]
        [TestCase(200,253,200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonHPStat(int initialEV, int addedEV, int expectedEV)
        {
            string testPokemonName = "Mewtwo";
            Pokemon testPokemonObject = new Pokemon(testPokemonName);
            testPokemonObject.AddEVPointsToHP(initialEV);
            testPokemonObject.AddEVPointsToHP(addedEV);
            int points = testPokemonObject.EVsHP;
            Assert.True(expectedEV.Equals(points));
        }


    }
}
