using System;

namespace _10.Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine()); //n
            int pokeDistance = int.Parse(Console.ReadLine()); //m
            int exhaustionFactor = int.Parse(Console.ReadLine()); //y

            int halvedPokePower = pokePower / 2;

            int pokes = 0;

            while (pokePower >= pokeDistance)
            {
                pokePower -= pokeDistance;

                pokes++;

                if (pokePower == halvedPokePower && exhaustionFactor > 0)
                {
                    pokePower = pokePower / exhaustionFactor;

                    if (pokePower < pokeDistance)
                    {
                            break;
                    }
                }

            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokes);
        }
    }
}
