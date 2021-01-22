using System;
using System.Collections.Generic;

namespace _05.Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                names.Add(Console.ReadLine());
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
