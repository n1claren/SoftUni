using System;
using System.Linq;

namespace _05.Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string[] oddLenghtWords = words.Where(w => w.Length % 2 == 0).ToArray();

            for (int i = 0; i < oddLenghtWords.Length; i++)
            {
                Console.WriteLine(oddLenghtWords[i]);
            }
        }
    }
}
