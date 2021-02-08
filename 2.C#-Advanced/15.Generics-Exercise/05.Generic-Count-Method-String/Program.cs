using System;
using System.Collections.Generic;

namespace _05.Generic_Count_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            List<string> genericList = new List<string>();

            for (int i = 0; i < inputs; i++)
            {
                string input = Console.ReadLine();

                genericList.Add(input);
            }

            string comparingElement = Console.ReadLine();

            Console.WriteLine(Compare(genericList, comparingElement));
        }

        public static int Compare<T>(List<T> list, T element)
          where T : IComparable<T>
        {
            int counter = 0;

            foreach (var generic in list)
            {
                if (generic.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
