using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fieldSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int fieldRows = fieldSize[0];
            int fieldCols = fieldSize[1];

            char[,] matrix = new char[fieldRows, fieldCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string directions = Console.ReadLine();

            int currentPlayerRow = 0;
            int currentPlayerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        currentPlayerRow = row;
                        currentPlayerCol = col;
                        break;
                    }
                }

                if (currentPlayerRow != 0)
                {
                    break;
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {
                char currentMove = directions[i];

                switch (currentMove)
                {
                    case 'U':

                        matrix[currentPlayerRow, currentPlayerCol] = '.';

                        if (ElementExists(currentPlayerRow - 1, currentPlayerCol, matrix))
                        {
                            currentPlayerRow = currentPlayerRow - 1;

                            BunniesSpeading(matrix);

                            if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                            {
                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        Console.Write(matrix[row, col]);
                                    }

                                    Console.WriteLine();
                                }

                                Console.WriteLine($"dead: {currentPlayerRow} {currentPlayerCol}");

                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            BunniesSpeading(matrix);

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col]);
                                }

                                Console.WriteLine();
                            }

                            Console.WriteLine($"won: {currentPlayerRow} {currentPlayerCol}");

                            Environment.Exit(0);
                        }

                        break;

                    case 'L':

                        matrix[currentPlayerRow, currentPlayerCol] = '.';

                        if (ElementExists(currentPlayerRow, currentPlayerCol - 1, matrix))
                        {
                            currentPlayerCol = currentPlayerCol - 1;

                            BunniesSpeading(matrix);

                            if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                            {
                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        Console.Write(matrix[row, col]);
                                    }

                                    Console.WriteLine();
                                }

                                Console.WriteLine($"dead: {currentPlayerRow} {currentPlayerCol}");

                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            BunniesSpeading(matrix);

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col]);
                                }

                                Console.WriteLine();
                            }

                            Console.WriteLine($"won: {currentPlayerRow} {currentPlayerCol}");

                            Environment.Exit(0);
                        }

                        break;

                    case 'R':

                        matrix[currentPlayerRow, currentPlayerCol] = '.';

                        if (ElementExists(currentPlayerRow, currentPlayerCol + 1, matrix))
                        {
                            currentPlayerCol = currentPlayerCol + 1;

                            BunniesSpeading(matrix);

                            if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                            {
                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        Console.Write(matrix[row, col]);
                                    }

                                    Console.WriteLine();
                                }

                                Console.WriteLine($"dead: {currentPlayerRow} {currentPlayerCol}");

                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            BunniesSpeading(matrix);

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col]);
                                }

                                Console.WriteLine();
                            }

                            Console.WriteLine($"won: {currentPlayerRow} {currentPlayerCol}");

                            Environment.Exit(0);
                        }

                        break;

                    case 'D':

                        matrix[currentPlayerRow, currentPlayerCol] = '.';

                        if (ElementExists(currentPlayerRow + 1, currentPlayerCol, matrix))
                        {
                            currentPlayerRow = currentPlayerRow + 1;

                            BunniesSpeading(matrix);

                            if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                            {
                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        Console.Write(matrix[row, col]);
                                    }

                                    Console.WriteLine();
                                }

                                Console.WriteLine($"dead: {currentPlayerRow} {currentPlayerCol}");

                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            BunniesSpeading(matrix);

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col]);
                                }

                                Console.WriteLine();
                            }

                            Console.WriteLine($"won: {currentPlayerRow} {currentPlayerCol}");

                            Environment.Exit(0);
                        }

                        break;
                }
            }
        }

        public static bool ElementExists(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        public static void BunnySpread(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] == 'B')
            {
                if (ElementExists(row + 1, col, matrix))
                {
                    matrix[row + 1, col] = 'B';
                }

                if (ElementExists(row - 1, col, matrix))
                {
                    matrix[row - 1, col] = 'B';
                }

                if (ElementExists(row, col + 1, matrix))
                {
                    matrix[row, col + 1] = 'B';
                }

                if (ElementExists(row, col - 1, matrix))
                {
                    matrix[row, col - 1] = 'B';
                }
            }
        }

        public static void BunniesSpeading(char[,] matrix)
        {
            List<List<int>> bunniesIndexes = new List<List<int>>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        List<int> temp = new List<int>();
                        temp.Add(row);
                        temp.Add(col);
                        bunniesIndexes.Add(temp);
                    }
                }
            }

            for (int z = 0; z < bunniesIndexes.Count; z++)
            {
                int currentBunnyRow = bunniesIndexes[z][0];
                int currentBunnyCol = bunniesIndexes[z][1];

                BunnySpread(currentBunnyRow, currentBunnyCol, matrix);
            }
        }
    }
}