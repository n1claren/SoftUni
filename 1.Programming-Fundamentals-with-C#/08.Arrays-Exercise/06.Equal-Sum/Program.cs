using System;
using System.Linq;

namespace _06.Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isEqual = false;

            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int k = 0; k < i; k++)
                {
                    leftSum += array[k];
                }

                for (int j = i + 1; j < array.Length; j++)
                {
                    rightSum += array[j];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isEqual = true;
                    break;
                }

            }

            if (isEqual == false)
            {
                Console.WriteLine("no");
            }

        }
    }
}
