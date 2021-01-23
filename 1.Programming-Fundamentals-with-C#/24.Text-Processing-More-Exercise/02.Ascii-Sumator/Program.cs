using System;

namespace _02.Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());

            char two = char.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > one && input[i] < two)
                {
                    sum += input[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}