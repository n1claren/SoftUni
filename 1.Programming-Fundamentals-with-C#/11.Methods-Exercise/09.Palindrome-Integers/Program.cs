using System;

namespace _09.Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberInput = Console.ReadLine().ToLower();

            while (numberInput != "end")
            {
                string currentString = numberInput;
                string reverseString = StringReverse(currentString);

                if (currentString == reverseString)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                numberInput = Console.ReadLine().ToLower();
            }
        }

        static string StringReverse(string text)
        {
            string reversedInput = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversedInput += text[i];
            }

            return reversedInput;
        }
    }
}
