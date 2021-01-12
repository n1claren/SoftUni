using System;
using System.Collections.Generic;

namespace _04.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }

                if (input[i] == ')')
                {
                    int endIndex = i;
                    int startIndex = brackets.Pop();

                    Console.WriteLine(input.Substring(startIndex, endIndex - startIndex + 1));
                }
            }
        }
    }
}
