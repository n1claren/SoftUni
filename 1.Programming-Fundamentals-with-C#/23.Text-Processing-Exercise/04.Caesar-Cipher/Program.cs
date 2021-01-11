using System;

namespace _04.Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                int current = input[i] + 3;

                result += (char)current;
            }

            Console.WriteLine(result);
        }
    }
}
