using System;
using System.Collections.Generic;

namespace _06.Generic_Count_Method_Double
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            List<double> genericList = new List<double>();

            for (int i = 0; i < inputs; i++)
            {
                double input = double.Parse(Console.ReadLine());

                genericList.Add(input);
            }

            double comparingElement = double.Parse(Console.ReadLine());

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
