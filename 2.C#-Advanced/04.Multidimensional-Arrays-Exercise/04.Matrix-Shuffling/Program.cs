using System;
using System.Linq;

namespace _04.Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RowsCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = RowsCols[0];
            int cols = RowsCols[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] actions = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (actions[0] != "swap" || actions.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int firstRow = int.Parse(actions[1]);
                int firstCol = int.Parse(actions[2]);
                int secondRow = int.Parse(actions[3]);
                int secondCol = int.Parse(actions[4]);

                if (firstRow >= matrix.GetLength(0) || firstRow < 0 ||
                    secondRow >= matrix.GetLength(0) || secondRow < 0 ||
                    firstCol >= matrix.GetLength(1) || firstCol < 0 ||
                    secondCol >= matrix.GetLength(1) || secondCol < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string firstTemp = matrix[firstRow, firstCol];
                string secondTemp = matrix[secondRow, secondCol];

                matrix[firstRow, firstCol] = secondTemp;
                matrix[secondRow, secondCol] = firstTemp;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
