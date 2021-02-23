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
        public WebPage _webPage;

        public NationalPokedexPage(WebPage webPage)
        {
            _webPage = webPage;
        }


        public WebElement ClickGeneration1Link()
        {
            Generation1Link = _webPage.SearchForThisElement(Generation1Link);
            _webPage.ClickElement(Generation1Link);
            return Generation1Link;
        }

        public WebElement ClickGeneration2Link()
        {
            Generation2Link = _webPage.SearchForThisElement(Generation2Link);
            _webPage.ClickElement(Generation2Link);
            return Generation2Link;
        }

        public WebElement ClickGeneration3Link()
        {
            Generation3Link = _webPage.SearchForThisElement(Generation3Link);
            _webPage.ClickElement(Generation3Link);
            return Generation3Link;
        }

        public WebElement ClickGeneration4Link()
        {
            Generation4Link = _webPage.SearchForThisElement(Generation4Link);
            _webPage.ClickElement(Generation4Link);
            return Generation4Link;
        }

        public WebElement ClickGeneration5Link()
        {
            Generation5Link = _webPage.SearchForThisElement(Generation5Link);
            _webPage.ClickElement(Generation5Link);
            return Generation5Link;
        }

        public WebElement ClickGeneration6Link()
        {
            Generation6Link = _webPage.SearchForThisElement(Generation6Link);
            _webPage.ClickElement(Generation6Link);
            return Generation6Link;
        }

        public WebElement ClickGeneration7Link()
        {
            Generation7Link = _webPage.SearchForThisElement(Generation7Link);
            _webPage.ClickElement(Generation7Link);
            return Generation7Link;
        }
        public WebElement ClickGeneration8Link()
        {
            Generation8Link = _webPage.SearchForThisElement(Generation8Link);
            _webPage.ClickElement(Generation8Link);
            return Generation8Link;
        }

        public WebElement FindPokemonTiles()
        {
            PokemonTile = _webPage.SearchForThisElement(PokemonTile);
            return PokemonTile;
        }

        public WebElement MoveIntoViewToPokemonNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new WebElement("a.ent-name[href='" + link + "']", "css");
            SpecificPokemonTile = _webPage.MoveIntoViewToThisElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }


        public WebElement ClickPokemonTileNamed(string Name)
        {
            string link = "/pokedex/" + Name.ToLower();
            SpecificPokemonTile = new WebElement("a.ent-name[href='" + link + "']", "css");
            SpecificPokemonTile = _webPage.ClickElement(SpecificPokemonTile);
            return SpecificPokemonTile;
        }

        public WebElement ClickPokemonTile()
        {
            if (SpecificPokemonTile.AmountElements == 1)
            {
                SpecificPokemonTile.AllMatchingResults[0].Click();
            }
            return SpecificPokemonTile;
        }

    }
}
