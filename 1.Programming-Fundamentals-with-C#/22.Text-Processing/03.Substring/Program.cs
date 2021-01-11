using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string banWord = Console.ReadLine();
            string word = Console.ReadLine();

            while (word.ToLower().IndexOf(banWord.ToLower()) != -1)
            {
                int index = word.ToLower().IndexOf(banWord.ToLower());

                word = word.Remove(index, banWord.Length);
            }

            Console.WriteLine(word);
        }
    }
}
