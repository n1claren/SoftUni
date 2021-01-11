using System;
using System.Linq;

namespace _05.Digits_Letters_And_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    Console.Write(input[i]);
                }
            }

            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    Console.Write(input[i]);
                }
            }

            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]) == false && Char.IsLetter(input[i]) == false)
                {
                    Console.Write(input[i]);
                }
            }
        }

    }
}
