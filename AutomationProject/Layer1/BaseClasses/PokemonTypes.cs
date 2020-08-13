using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTypesNamespace
{
    public class PokemonTypes
    {
        public string TypeName;
        public List<PokemonTypes> WeakToAttacks = new List<PokemonTypes>();
        public List<PokemonTypes> ImmuneToAttacks = new List<PokemonTypes>();
        public List<PokemonTypes> NeutralToAttacks = new List<PokemonTypes>();
        public List<PokemonTypes> ResistantToAttacks = new List<PokemonTypes>();
        public List<PokemonTypes> AttacksWeakOn = new List<PokemonTypes>();
        public List<PokemonTypes> AttacksNeutralOn = new List<PokemonTypes>();
        public List<PokemonTypes> AttacksStrongOn = new List<PokemonTypes>();
        public List<PokemonTypes> AttacksWontWork = new List<PokemonTypes>();

        public PokemonTypes(string type)
        {
            TypeName = type;
        }
    }
}
