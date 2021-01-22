using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];

            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int[] bombIndexes = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < bombIndexes.Length; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }

                int bombRow = bombIndexes[i];
                int bombCol = bombIndexes[i + 1];

                ExplodingBomb(bombRow, bombCol, jagged);
            }

            int aliveCells = 0;
            int aliveCellsSum = 0;

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] > 0)
                    {
                        aliveCells++;
                        aliveCellsSum += jagged[row][col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(' ', jagged[row]));
            }
        }

        public static bool ElementExists(int row, int col, int[][] jagged)
        {
            if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
            {
                return true;
            }

            return false;
        }

        public static void ExplodingBomb(int bombRow, int bombCol, int[][] jagged)
        {
            if (ElementExists(bombRow, bombCol, jagged) && jagged[bombRow][bombCol] > 0)
            {
                int bombPower = jagged[bombRow][bombCol];

                jagged[bombRow][bombCol] = 0;

                for (int row = bombRow - 1; row <= bombRow + 1; row++)
                {
                    for (int col = bombCol - 1; col <= bombCol + 1; col++)
                    {
                        if (ElementExists(row, col, jagged) && jagged[row][col] > 0)
                        {
                            jagged[row][col] -= bombPower;
                        }
                    }
                }
            }
        }


    }
}