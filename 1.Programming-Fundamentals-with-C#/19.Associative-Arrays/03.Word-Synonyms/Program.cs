using System;
using System.Collections.Generic;

namespace _03.Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfWords = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < countOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].Add(synonym);
                }
                else
                {
                    dictionary.Add(word, new List<string>());
                    dictionary[word].Add(synonym);
                }
            }

            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key} - { string.Join(", ", word.Value) }");
            }
        }
    }
}
