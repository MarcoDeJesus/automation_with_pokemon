using APIModules;
using System;
namespace AutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonFactory Mewtwo = new PokemonFactory("Mewtwo");
            Pokemon MewtwoInstance = new Pokemon(Mewtwo, true);
            MewtwoInstance.PrintEVs();
            MewtwoInstance.PrintIVs();
            Console.WriteLine(MewtwoInstance.IsShiny);
            Console.ReadLine();
        }
    }
}
