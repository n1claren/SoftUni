using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int leftBorder = int.Parse(Console.ReadLine());
            int rightBorder = int.Parse(Console.ReadLine());
            int combineNumber = int.Parse(Console.ReadLine());

            int combinationCounter = 0;
            bool combinationFound = false;

            for (int a = leftBorder; a <= rightBorder; a++)
            {
                for (int b = leftBorder; b <= rightBorder; b++)
                {
                    combinationCounter++;

                    if (a+b==combineNumber)
                    {
                        combinationFound = true;
                        Console.WriteLine($"Combination N:{combinationCounter} ({a} + {b} = {combineNumber})");
                        break;
                    }
                }

                if (combinationFound)
                {
                    break;
                }
            }

            if (!combinationFound)
            {
                Console.WriteLine($"{combinationCounter} combinations - neither equals {combineNumber}");
            }    
        }
    }
}
