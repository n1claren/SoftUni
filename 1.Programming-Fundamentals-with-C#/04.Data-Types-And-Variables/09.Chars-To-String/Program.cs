using System;

namespace _09.Chars_To_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                string input = Console.ReadLine();

                result += input;
            }

            Console.WriteLine(result);
        }
    }
}
