using System;

namespace _02.Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            VowelCounter(input);
        }

        static void VowelCounter(string text)
        {
            int vowelCounter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' ||
                    text[i] == 'e' ||
                    text[i] == 'i' ||
                    text[i] == 'o' ||
                    text[i] == 'u' ||
                    text[i] == 'y')
                {
                    vowelCounter++;
                }
            }

            Console.WriteLine(vowelCounter);
        }
    }
}
