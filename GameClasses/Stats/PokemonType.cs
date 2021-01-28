using GameInterfaces;

namespace StatsManagement
{
    public class PokemonTypes : IPokemonType
    {
        public string TypeName;
        public int TypeSlot;
        public int TypeID;

        public PokemonTypes()
        { }

        public PokemonTypes(string type)
        {
            TypeName = type;
        }
    }
}