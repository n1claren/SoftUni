using System;
using System.Linq;

namespace _05.Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                bool isBigger = true;

                for (int k = i + 1; k < array.Length; k++)
                {
                    if (array[i] > array[k])
                    {
                        isBigger = true;
                    }
                    else
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}
