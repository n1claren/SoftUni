using System;
using System.Collections.Generic;

namespace _01.Count_Chars_In_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> charCounter = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == ' ')
                {
                    continue;
                }

                if (charCounter.ContainsKey(symbol))
                {
                    charCounter[symbol]++;
                }
                else
                {
                    charCounter.Add(symbol, 1);
                }
            }

            foreach (var item in charCounter)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
