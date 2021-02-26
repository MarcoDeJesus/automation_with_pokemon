using OpenQA.Selenium;
using PageObjects;

namespace UIModules
{
    public class PokemonDBHomeModule
    {

        public WebPage _wp;
        private string WebBrowser;


        public PokemonDBHomeModule(WebPage wp)
        {
            _wp = wp;
        }


        public void GoToThisPage()
        {
            _wp.LoadWebPage("https://pokemondb.net/");
        }


        public void UserClicksNationalPokedexQuickLink()
        {
            PokemonDBHome HomePageObject = new PokemonDBHome(_wp);
            HomePageObject.ClickNationalDexLink();
        }

        public void CloseModalIfPresent()
        {
            PokemonDBHome HomePageObject = new PokemonDBHome(_wp);
            int countElements = HomePageObject.FindModalOkButton().AmountElements;
            if (countElements == 1)
            {
                HomePageObject.ClickOKModalButton();
            }
        }
    }
}
