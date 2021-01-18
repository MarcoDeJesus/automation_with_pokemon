using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using PokemonTypesNamespace;
using System.Collections.Generic;

namespace AutomationProject.Layer2.UI
{
    class PokemonDetailPageModule
    {

        public IWebDriver CurrentDriver;
        private string WebBrowser;

        public PokemonDetailPageModule(IWebDriver driver)
        {
            CurrentDriver = driver;
        }


        public string FindPokemonNameInPage()
        {
            PokemonDetailPagePokedex DexObject = new PokemonDetailPagePokedex(CurrentDriver);
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
            PokemonDetailPagePokedex DexObject = new PokemonDetailPagePokedex(CurrentDriver);
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
            PokemonDetailPagePokedex DexObject = new PokemonDetailPagePokedex(CurrentDriver);
            WebElement PokemonTypes = DexObject.FindPokemonTypesLabels();
            List<PokemonTypes> TypesPage = new List<PokemonTypes>();
            int amountTypes = PokemonTypes.AllMatchingResults.Count;
            for (int i = 0; i <= amountTypes - 1; i++)
            {
                PokemonTypes Type = new PokemonTypes();
                Type.TypeName = PokemonTypes.AllMatchingResults[i].Text;
                Type.TypeSlot = i + 1;
                TypesPage.Add(Type);
            }
            return TypesPage;
        }

        public string FindPokemonBaseHP()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats(CurrentDriver);
            StatsObject.FindHPBaseStatusData();
            string hp = null;
            if (StatsObject.TabBasicContainer_StatsContainer_BaseStatHP.AllMatchingResults.Count == 1)
            {
                hp = StatsObject.TabBasicContainer_StatsContainer_BaseStatHP.AllMatchingResults[0].Text;
            }
            return hp;
        }

        public string FindPokemonBaseAttack()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats(CurrentDriver);
            StatsObject.FindAttackBaseStatusData();
            string att = null;
            if (StatsObject.TabBasicContainer_StatsContainer_BaseStatAttack.AllMatchingResults.Count == 1)
            {
                att = StatsObject.TabBasicContainer_StatsContainer_BaseStatAttack.AllMatchingResults[0].Text;
            }
            return att;
        }

        public string FindPokemonBaseDefense()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats(CurrentDriver);
            StatsObject.FindDefenseBaseStatusData();
            string def = null;
            if (StatsObject.TabBasicContainer_StatsContainer_BaseStatDefense.AllMatchingResults.Count == 1)
            {
                def = StatsObject.TabBasicContainer_StatsContainer_BaseStatDefense.AllMatchingResults[0].Text;
            }
            return def;
        }

        public string FindPokemonBaseSpAttack()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats(CurrentDriver);
            StatsObject.FindSpAttackBaseStatusData();
            string spa = null;
            if (StatsObject.TabBasicContainer_StatsContainer_BaseStatSpAttack.AllMatchingResults.Count == 1)
            {
                spa = StatsObject.TabBasicContainer_StatsContainer_BaseStatSpAttack.AllMatchingResults[0].Text;
            }
            return spa;
        }

        public string FindPokemonBaseSpDefense()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats(CurrentDriver);
            StatsObject.FindSpDefenseBaseStatusData();
            string spd = null;
            if (StatsObject.TabBasicContainer_StatsContainer_BaseStatSpDefense.AllMatchingResults.Count == 1)
            {
                spd = StatsObject.TabBasicContainer_StatsContainer_BaseStatSpDefense.AllMatchingResults[0].Text;
            }
            return spd;
        }

        public string FindPokemonBaseSpeed()
        {
            PokemonDetailPageStats StatsObject = new PokemonDetailPageStats(CurrentDriver);
            StatsObject.FindSpeedBaseStatusData();
            string spe = null;
            if (StatsObject.TabBasicContainer_StatsContainer_BaseStatSpeed.AllMatchingResults.Count == 1)
            {
                spe = StatsObject.TabBasicContainer_StatsContainer_BaseStatSpeed.AllMatchingResults[0].Text;
            }
            return spe;
        }

        public string GetPokemonPrimaryType()
        {
            string type = null;
            List<PokemonTypes> Types = FindPokemonTypes();
            foreach (PokemonTypes pkt in Types)
            {
                if (pkt.TypeSlot == 1)
                {
                    type = pkt.TypeName;
                    break;
                }
            }
            return type;
        }


        public bool ThisPokemonHasASecondType()
        {
            bool hasSecond = false;
            List<PokemonTypes> Types = FindPokemonTypes();
            foreach (PokemonTypes pkt in Types)
            {
                if (pkt.TypeSlot == 2)
                {
                    hasSecond = true;
                    break;
                }
            }
            return hasSecond;
        }

        public string GetPokemonSecondaryType()
        {
            string type = null;
            List<PokemonTypes> Types = FindPokemonTypes();
            foreach (PokemonTypes pkt in Types)
            {
                if (pkt.TypeSlot == 2)
                {
                    type = pkt.TypeName;
                    break;
                }
            }
            return type;
        }


    }
}
