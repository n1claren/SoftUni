using System;
using System.Collections.Generic;

namespace _06.Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] charArr = input.ToCharArray();

            List<string> result = new List<string>();

            for (int i = 0; i < charArr.Length; i++)
            {
                result.Add(charArr[i].ToString());
            }

            for (int i = 1; i < result.Count; i++)
            {
                if (result[i] == result[i - 1])
                {
                    result.RemoveAt(i - 1);
                    i--;
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
