using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine().Split();

            char[,] matrix = new char[fieldSize, fieldSize];

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

            int startingRow = 0;
            int startingCol = 0;
            int coalGathered = 0;
            int currentCoal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startingRow = row;
                        startingCol = col;
                    }    

                    if (matrix[row, col] == 'c')
                    {
                        currentCoal++;
                    }
                }

            }

            for (int i = 0; i < directions.Length; i++)
            {
                string currentMove = directions[i];

                switch (currentMove)
                {
                    case "up":

                        if (!ElementExists(startingRow - 1, startingCol, matrix))
                        {
                            break;
                        }

                        startingRow = startingRow - 1;

                        if (matrix[startingRow, startingCol] == 'c')
                        {
                            coalGathered++;
                            currentCoal--;

                            matrix[startingRow, startingCol] = '*';

                            if (currentCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startingRow}, {startingCol})");

                                Environment.Exit(0);
                            }
                        }

                        if (matrix[startingRow, startingCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startingRow}, {startingCol})");

                            Environment.Exit(0);
                        }

                        break;

                    case "down":

                        if (!ElementExists(startingRow + 1, startingCol, matrix))
                        {
                            break;
                        }

                        startingRow = startingRow + 1;

                        if (matrix[startingRow, startingCol] == 'c')
                        {
                            coalGathered++;
                            currentCoal--;

                            matrix[startingRow, startingCol] = '*';

                            if (currentCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startingRow}, {startingCol})");

                                Environment.Exit(0);
                            }
                        }

                        if (matrix[startingRow, startingCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startingRow}, {startingCol})");

                            Environment.Exit(0);
                        }

                        break;

                    case "left":

                        if (!ElementExists(startingRow, startingCol - 1, matrix))
                        {
                            break;
                        }

                        startingCol = startingCol - 1;

                        if (matrix[startingRow, startingCol] == 'c')
                        {
                            coalGathered++;
                            currentCoal--;

                            matrix[startingRow, startingCol] = '*';

                            if (currentCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startingRow}, {startingCol})");

                                Environment.Exit(0);
                            }
                        }

                        if (matrix[startingRow, startingCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startingRow}, {startingCol})");

                            Environment.Exit(0);
                        }

                        break;

                    case "right":

                        if (!ElementExists(startingRow, startingCol + 1, matrix))
                        {
                            break;
                        }

                        startingCol = startingCol + 1;

                        if (matrix[startingRow, startingCol] == 'c')
                        {
                            coalGathered++;
                            currentCoal--;

                            matrix[startingRow, startingCol] = '*';

                            if (currentCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startingRow}, {startingCol})");

                                Environment.Exit(0);
                            }
                        }

                        if (matrix[startingRow, startingCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startingRow}, {startingCol})");

                            Environment.Exit(0);
                        }

                        break;
                }
            }

            Console.WriteLine($"{currentCoal} coals left. ({startingRow}, {startingCol})");
        }

        public static bool ElementExists(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

    }
}
