using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTypesNamespace
{
    public class PokemonTypes
    {
        public string TypeName;
        public int TypeSlot;

        public PokemonTypes()
        { }

        public PokemonTypes(string type)
        {
            TypeName = type;
        }
    }
}
