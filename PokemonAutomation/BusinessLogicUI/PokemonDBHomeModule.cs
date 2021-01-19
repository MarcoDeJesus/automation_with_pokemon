using OpenQA.Selenium;
using PageObjects;

namespace UIModules
{
    public class PokemonDBHomeModule
    {

        public IWebDriver CurrentDriver;
        private string WebBrowser;


        public PokemonDBHomeModule(IWebDriver driver)
        {
            CurrentDriver = driver;
        }


        public void GoToThisPage()
        {
            CurrentDriver.Navigate().GoToUrl("https://pokemondb.net/");
        }


        public void UserClicksNationalPokedexQuickLink ()
        {
            PokemonDBHome HomePageObject = new PokemonDBHome(CurrentDriver);
            HomePageObject.ClickNationalDexLink();
        }
    }
}
