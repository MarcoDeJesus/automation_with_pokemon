using NUnit.Framework;
using StatsManagement;

namespace AutomationATDD
{
    public class PokemonEVManagement
    {

        [Test]
        [TestCase(200, 253, 200)]
        [TestCase(200, 52, 252)]
        [TestCase(100, 52, 152)]
        [TestCase(-1, -1, 0)]
        public void AddingEVsIntoPokemonHPStat(int initialEV, int addedEV, int expectedEV)
        {
            EVManagement evObject = new EVManagement();
            evObject.AddEVPointsToHP(initialEV);
            evObject.AddEVPointsToHP(addedEV);
            int points = evObject.hp;
            Assert.True(expectedEV.Equals(points));
        }
    }
}