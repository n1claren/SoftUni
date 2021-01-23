using System;
using System.Collections.Generic;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> uniqueNames = new List<string>();

            int names = int.Parse(Console.ReadLine());

            for (int i = 0; i < names; i++)
            {
                string input = Console.ReadLine();

                if (!uniqueNames.Contains(input))
                {
                    uniqueNames.Add(input);
                }
            }

            for (int i = 0; i < uniqueNames.Count; i++)
            {
                Console.WriteLine(uniqueNames[i]);
            }
        }
    }
}
