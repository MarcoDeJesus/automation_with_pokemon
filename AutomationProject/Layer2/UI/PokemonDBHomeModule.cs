using PageObjects;

namespace UIModules
{
    public class PokemonDBHomeModule
    {
        public void UserClicksNationalPokedexQuickLink ()
        {
            PokemonDBHome HomePageObject = new PokemonDBHome();
            HomePageObject.ClickNationalDexLink();
        }
    }
}
