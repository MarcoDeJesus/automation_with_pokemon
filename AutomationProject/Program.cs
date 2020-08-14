/***
namespace AutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonFactory Mewtwo = new PokemonFactory("Mewtwo");
            Console.WriteLine(Mewtwo.Number);
            Console.WriteLine(Mewtwo.BaseSpecialAttack);
            Console.WriteLine(Mewtwo.BaseSpeed);
            foreach (PokemonAbility ab in Mewtwo.PokemonAbilities)
            {
                Console.WriteLine(ab.AbilityName);
            }
            foreach (PokemonTypes ty in Mewtwo.PokemonTypes)
            {
                Console.WriteLine(ty.TypeName);
            }
        }
    }
}***/
