using System;
using System.Linq;

namespace _04.Fold_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int leftFoldIndex = initialArray.Length / 4 - 1;
            int rightFoldIndex = 3 * initialArray.Length / 4;

            int[] topArray = new int[initialArray.Length / 2];

            int numbers = 0;

            for (int i = leftFoldIndex; i >= 0; i--)
            {
                numbers++;

                topArray[leftFoldIndex - i] = initialArray[i];
            }

            for (int i = initialArray.Length - 1; i >= rightFoldIndex; i--)
            {
                topArray[initialArray.Length - 1 - i + numbers] = initialArray[i];
            }


            int[] bottomArray = new int[initialArray.Length / 2];

            for (int i = leftFoldIndex + 1; i < rightFoldIndex; i++)
            {
                bottomArray[i - numbers] = initialArray[i];
            }


            for (int i = 0; i < topArray.Length; i++)
            {
                Console.Write(topArray[i] + bottomArray[i] + " ");
            }
        }
    }
}
