using System;

namespace _06.Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string straightChars = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                string charr = Console.ReadLine();

                straightChars += charr;
            }

            for (int i = straightChars.Length - 1; i >= 0; i--)
            {
                Console.Write(straightChars[i] + " ");
            }

        }
    }
}
