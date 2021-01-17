using System;
using System.Linq;

namespace _05.Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCows = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = rowsCows[0];
            int cols = rowsCows[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int rowElement = 0; rowElement < currentRow.Length; rowElement++)
                {
                    matrix[row, rowElement] = currentRow[rowElement];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int squareSum = matrix[row, col] +
                                    matrix[row + 1, col] +
                                    matrix[row, col + 1] +
                                    matrix[row + 1, col + 1];

                    if (squareSum > maxSum)
                    {
                        maxSum = squareSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int row = maxRow; row < maxRow + 2; row++)
            {
                for (int col = maxCol; col < maxCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
