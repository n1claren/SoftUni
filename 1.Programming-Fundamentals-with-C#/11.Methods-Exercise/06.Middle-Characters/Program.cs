using System;

namespace _06.Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleCharacters(input);
        }

        static void PrintMiddleCharacters(string text)
        {
            int textLenght = text.Length;
            int temp1 = 0;
            int temp2 = 0;

            if (textLenght % 2 == 0)
            {
                temp1 = textLenght / 2 - 1;
                temp2 = (textLenght / 2);
                Console.WriteLine($"{text[temp1]}{text[temp2]}");
            }

            else
            {
                temp1 = (textLenght / 2);
                Console.WriteLine(text[temp1]);
            }
        }
    }
}
