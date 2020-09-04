using Features;

namespace APIModules
{
    public class PokemonFactoryModule
    {
        public Pokemon GenerateThisPokemonUsingTheFactory(string name)
        {
            Pokemon TestPokemon = new Pokemon(name);
            return TestPokemon;
        }
    }
}
