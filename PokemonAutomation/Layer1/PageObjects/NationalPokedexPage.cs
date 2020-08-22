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


        public WebElement ClickGeneration1Link()
        {
            Generation1Link = WebPage.ClickElement(Generation1Link);
            return Generation1Link;
        }

        public WebElement ClickGeneration2Link()
        {
            Generation2Link = WebPage.ClickElement(Generation2Link);
            return Generation2Link;
        }

        public WebElement ClickGeneration3Link()
        {
            Generation3Link = WebPage.ClickElement(Generation3Link);
            return Generation3Link;
        }

        public WebElement ClickGeneration4Link()
        {
            Generation4Link = WebPage.ClickElement(Generation4Link);
            return Generation4Link;
        }

        public WebElement ClickGeneration5Link()
        {
            Generation5Link = WebPage.ClickElement(Generation5Link);
            return Generation5Link;
        }

        public WebElement ClickGeneration6Link()
        {
            Generation6Link = WebPage.ClickElement(Generation6Link);
            return Generation6Link;
        }

        public WebElement ClickGeneration7Link()
        {
            Generation7Link = WebPage.ClickElement(Generation7Link);
            return Generation7Link;
        }
        public WebElement ClickGeneration8Link()
        {
            Generation8Link = WebPage.ClickElement(Generation8Link);
            return Generation8Link;
        }

        public WebElement FindPokemonTiles()
        {
            PokemonTile.SearchForThisElement();
            return PokemonTile;
        }

        public WebElement MoveIntoViewToPokemonNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new WebElement("a.ent-name[href='" + link + "']", "css");
            SpecificPokemonTile.SearchForThisElement();
            if (SpecificPokemonTile.AllMatchingResults.Count == 1)
            {
                Actions actions = WebPage.NewActionsObject();
                actions.MoveToElement(SpecificPokemonTile.AllMatchingResults[0]);
                actions.Perform();
            }
            return SpecificPokemonTile;
        }

        public WebElement MoveIntoViewToTile()
        {
            if (SpecificPokemonTile.AllMatchingResults.Count == 1)
            {
                Actions actions = WebPage.NewActionsObject();
                actions.MoveToElement(SpecificPokemonTile.AllMatchingResults[0]);
                actions.Perform();
            }
            return SpecificPokemonTile;
        }


        public WebElement ClickPokemonTileNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new WebElement("a.ent-name[href='" + link + "']", "css");
            SpecificPokemonTile = WebPage.ClickElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }

        public WebElement ClickPokemonTile()
        {
            if (SpecificPokemonTile.AllMatchingResults.Count == 1)
            {
                SpecificPokemonTile.AllMatchingResults[0].Click();
            }
            return SpecificPokemonTile;
        }

    }
}
