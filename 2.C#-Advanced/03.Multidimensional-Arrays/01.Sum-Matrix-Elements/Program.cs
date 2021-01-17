using System;
using System.Linq;

namespace _01.Sum_Matrix_Elements
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

            int matrixSum = 0;

            foreach (var element in matrix)
            {
                matrixSum += element;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(matrixSum);
        }
    }
}
