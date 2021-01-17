using System;
using System.Linq;

namespace _02.Sum_Matrix_Columns
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
                .Split()
                .Select(int.Parse)
                .ToArray();

                for (int rowElement = 0; rowElement < currentRow.Length; rowElement++)
                {
                    matrix[row, rowElement] = currentRow[rowElement];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int colSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    colSum += matrix[row, col];
                }

                Console.WriteLine(colSum);
            }
        }
    }
}
