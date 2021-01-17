using System;
using System.Linq;

namespace _03.Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSide = int.Parse(Console.ReadLine());

            int[,] matrix = new int[squareSide, squareSide];

            for (int row = 0; row < squareSide; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < squareSide; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primaryDiagonalSum += matrix[row, row];
            }

            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
