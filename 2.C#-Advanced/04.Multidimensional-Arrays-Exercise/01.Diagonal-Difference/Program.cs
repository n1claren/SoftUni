using System;
using System.Linq;

namespace _01.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSide = int.Parse(Console.ReadLine());

            int[,] matrix = new int[squareSide, squareSide];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primaryDiagonalSum += matrix[row, row];
            }

            int secondaryDiagonalSum = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                secondaryDiagonalSum += matrix[row, Math.Abs(row - (squareSide - 1))];
            }

            int result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(result);
        }
    }
}
