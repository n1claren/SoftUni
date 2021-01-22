using System;
using System.Linq;

namespace _05.Snake_Moves
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

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            int currentLetter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[currentLetter];

                        currentLetter++;

                        if (currentLetter == snake.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[currentLetter];

                        currentLetter++;

                        if (currentLetter == snake.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = string.Empty;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    currentRow += matrix[row, col];
                }

                Console.WriteLine(currentRow);
            }
        }
    }
}
