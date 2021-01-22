using System;
using System.Linq;

namespace _02.Squares_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RowsCols = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = RowsCols[0];
            int cols = RowsCols[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int squareCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col +1])
                    {
                        squareCount++;
                    }    
                }
            }

            Console.WriteLine(squareCount);
        }
    }
}
