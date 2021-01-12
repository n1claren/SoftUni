using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reverseInput = new Stack<char>(input);

            while (reverseInput.Count > 0)
            {
                Console.Write(reverseInput.Pop());
            }
        }
    }
}
