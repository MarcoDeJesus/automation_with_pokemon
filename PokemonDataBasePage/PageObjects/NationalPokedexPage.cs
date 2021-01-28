using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects
{
    public class NationalPokedexPage
    {

        public WebElement Generation1Link = new WebElement("a[href='#gen-1']", "css");
        public WebElement Generation2Link = new WebElement("a[href='#gen-2']", "css");
        public WebElement Generation3Link = new WebElement("a[href='#gen-3']", "css");
        public WebElement Generation4Link = new WebElement("a[href='#gen-4']", "css");
        public WebElement Generation5Link = new WebElement("a[href='#gen-5']", "css");
        public WebElement Generation6Link = new WebElement("a[href='#gen-6']", "css");
        public WebElement Generation7Link = new WebElement("a[href='#gen-7']", "css");
        public WebElement Generation8Link = new WebElement("a[href='#gen-8']", "css");
        public WebElement PokemonTile = new WebElement("a.ent-name","css");
        public WebElement SpecificPokemonTile = new WebElement();
        public IWebDriver _driver;

        public NationalPokedexPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public WebElement ClickGeneration1Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation1Link = genericPage.ClickElement(Generation1Link);
            return Generation1Link;
        }

        public WebElement ClickGeneration2Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation2Link = genericPage.ClickElement(Generation2Link);
            return Generation2Link;
        }

        public WebElement ClickGeneration3Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation3Link = genericPage.ClickElement(Generation3Link);
            return Generation3Link;
        }

        public WebElement ClickGeneration4Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation4Link = genericPage.ClickElement(Generation4Link);
            return Generation4Link;
        }

        public WebElement ClickGeneration5Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation5Link = genericPage.ClickElement(Generation5Link);
            return Generation5Link;
        }

        public WebElement ClickGeneration6Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation6Link = genericPage.ClickElement(Generation6Link);
            return Generation6Link;
        }

        public WebElement ClickGeneration7Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation7Link = genericPage.ClickElement(Generation7Link);
            return Generation7Link;
        }
        public WebElement ClickGeneration8Link()
        {
            WebPage genericPage = new WebPage(_driver);
            Generation8Link = genericPage.ClickElement(Generation8Link);
            return Generation8Link;
        }

        public WebElement FindPokemonTiles()
        {
            PokemonTile.SearchForThisElement(_driver);
            return PokemonTile;
        }

        public WebElement MoveIntoViewToPokemonNamed(string Name)
        {
            WebPage genericPage = new WebPage(_driver);
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new WebElement("a.ent-name[href='" + link + "']", "css");
            SpecificPokemonTile.SearchForThisElement(_driver);
            if (SpecificPokemonTile.AllMatchingResults.Count == 1)
            {
                Actions actions = genericPage.NewActionsObject();
                actions.MoveToElement(SpecificPokemonTile.AllMatchingResults[0]);
                actions.Perform();
            }
            return SpecificPokemonTile;
        }

        public WebElement MoveIntoViewToTile()
        {
            WebPage genericPage = new WebPage(_driver);
            if (SpecificPokemonTile.AllMatchingResults.Count == 1)
            {
                Actions actions = genericPage.NewActionsObject();
                actions.MoveToElement(SpecificPokemonTile.AllMatchingResults[0]);
                actions.Perform();
            }
            return SpecificPokemonTile;
        }


        public WebElement ClickPokemonTileNamed(string Name)
        {
            WebPage genericPage = new WebPage(_driver);
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new WebElement("a.ent-name[href='" + link + "']", "css");
            SpecificPokemonTile = genericPage.ClickElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }

        public WebElement ClickPokemonTile()
        {
            WebPage genericPage = new WebPage(_driver);
            if (SpecificPokemonTile.AllMatchingResults.Count == 1)
            {
                SpecificPokemonTile.AllMatchingResults[0].Click();
            }
            return SpecificPokemonTile;
        }

    }
}
