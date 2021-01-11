using System;

namespace _04.Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

            for (int i = 0; i < banWords.Length; i++)
            {
                string bannedWord = new string('*', banWords[i].Length);

                text = text.Replace(banWords[i], bannedWord);
            }

            Console.WriteLine(text);
        }
    }
}
