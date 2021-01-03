using System;

namespace _03.Characters_In_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharactersInRange(firstChar, secondChar);
        }

        static void CharactersInRange(char a, char b)
        {
            if (a < b)
            {
                for (int i = a + 1; i < b; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = b + 1; i < a; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }

    }
}
