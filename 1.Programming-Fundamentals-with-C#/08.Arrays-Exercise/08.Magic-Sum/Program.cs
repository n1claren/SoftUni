using System;
using System.Linq;

namespace _08.Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i + 1; k < array.Length; k++)
                {
                    if (array[i] + array[k] == n)
                    {
                        Console.WriteLine($"{array[i]} {array[k]}");
                    }
                }
            }

        }
    }
}
