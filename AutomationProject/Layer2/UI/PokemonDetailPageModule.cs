using NUnit.Framework;
using PageObjects;
using PokemonTypesNamespace;
using System.Collections.Generic;

namespace AutomationProject.Layer2.UI
{
    class PokemonDetailPageModule
    {

        public string FindPokemonNameInPage()
        {
            PokemonDetailPagePokedex DexObject = new PokemonDetailPagePokedex();
            WebElement PokemonName = DexObject.FindPokemonNameHeaderLabel();
            string name = null;
            if (PokemonName.AllMatchingResults.Count == 1)
            {
                name = PokemonName.AllMatchingResults[0].Text;
            }
            return name;
        }

        public string FindPokemonNationalNumber()
        {
            PokemonDetailPagePokedex DexObject = new PokemonDetailPagePokedex();
            WebElement PokemonNumber = DexObject.FindNationalDexNumberLabel();
            string number = null;
            if (PokemonNumber.AllMatchingResults.Count == 1)
            {
                number = PokemonNumber.AllMatchingResults[0].Text;
            }
            return number;
        }

        public List<PokemonTypes> FindPokemonTypes()
        {
            PokemonDetailPagePokedex DexObject = new PokemonDetailPagePokedex();
            WebElement PokemonNumber = DexObject.FindNationalDexNumberLabel();
            List<PokemonTypes> TypesPage = new List<PokemonTypes>();
            int amountTypes = PokemonNumber.AllMatchingResults.Count;
            for (int i = 0; i <= amountTypes - 1; i++)
            {
                PokemonTypes Type = new PokemonTypes();
                Type.TypeName = PokemonNumber.AllMatchingResults[i].Text;
                Type.TypeSlot = i + 1;
                TypesPage.Add(Type);
            }
            return TypesPage;
        }

        public string FindPokemonBaseHP()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats();
            StatsObject.FindHPBaseStatusData();
            string hp = null;
            if (StatsObject.BaseStatHP.AllMatchingResults.Count == 1)
            {
                hp = StatsObject.BaseStatHP.AllMatchingResults[0].Text;
            }
            return hp;
        }

        public string FindPokemonBaseAttack()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats();
            StatsObject.FindAttackBaseStatusData();
            string att = null;
            if (StatsObject.BaseStatAttack.AllMatchingResults.Count == 1)
            {
                att = StatsObject.BaseStatAttack.AllMatchingResults[0].Text;
            }
            return att;
        }

        public string FindPokemonBaseDefense()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats();
            StatsObject.FindDefenseBaseStatusData();
            string def = null;
            if (StatsObject.BaseStatDefense.AllMatchingResults.Count == 1)
            {
                def = StatsObject.BaseStatDefense.AllMatchingResults[0].Text;
            }
            return def;
        }

        public string FindPokemonBaseSpAttack()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats();
            StatsObject.FindSpAttackBaseStatusData();
            string spa = null;
            if (StatsObject.BaseStatSpAttack.AllMatchingResults.Count == 1)
            {
                spa = StatsObject.BaseStatSpAttack.AllMatchingResults[0].Text;
            }
            return spa;
        }

        public string FindPokemonBaseSpDefense()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats();
            StatsObject.FindSpDefenseBaseStatusData();
            string spd = null;
            if (StatsObject.BaseStatSpDefense.AllMatchingResults.Count == 1)
            {
                spd = StatsObject.BaseStatSpDefense.AllMatchingResults[0].Text;
            }
            return spd;
        }

        public string FindPokemonBaseSpeed()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats();
            StatsObject.FindSpeedBaseStatusData();
            string spe = null;
            if (StatsObject.BaseStatSpeed.AllMatchingResults.Count == 1)
            {
                spe = StatsObject.BaseStatSpeed.AllMatchingResults[0].Text;
            }
            return spe;
        }


    }
}
