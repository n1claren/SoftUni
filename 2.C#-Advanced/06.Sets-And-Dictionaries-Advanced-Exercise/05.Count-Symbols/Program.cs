using System;
using System.Collections.Generic;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> characters = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (char character in input)
            {
                if (!characters.ContainsKey(character))
                {
                    characters.Add(character, 0);
                }

                characters[character]++;
            }

            foreach (var kvp in characters)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
