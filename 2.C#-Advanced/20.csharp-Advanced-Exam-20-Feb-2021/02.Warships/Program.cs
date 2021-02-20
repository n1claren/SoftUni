using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[fieldSize, fieldSize];

            string[] coordinates = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            int playerOneShips = 0;
            int playerTwoShips = 0;
            int shipsDestroyed = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (currentRow[col] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentCoordinates = coordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = currentCoordinates[0];
                int currentCol = currentCoordinates[1];

                if (!IndexExists(currentRow, currentCol, matrix))
                {
                    continue;
                }

                if (matrix[currentRow, currentCol] == '*')
                {
                    continue;
                }
                else if (matrix[currentRow, currentCol] == '<')
                {
                    matrix[currentRow, currentCol] = 'X';
                    playerOneShips--;
                    shipsDestroyed++;
                }
                else if (matrix[currentRow, currentCol] == '>')
                {
                    matrix[currentRow, currentCol] = 'X';
                    playerTwoShips--;
                    shipsDestroyed++;
                }
                else if (matrix[currentRow, currentCol] == '#')
                {
                    if (IndexExists(currentRow -1, currentCol - 1, matrix))
                    {
                        if (matrix[currentRow - 1, currentCol - 1] == '<')
                        {
                            matrix[currentRow - 1, currentCol - 1] = 'X';
                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow - 1, currentCol - 1] == '>')
                        {
                            matrix[currentRow - 1, currentCol - 1] = 'X';
                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (IndexExists(currentRow - 1, currentCol, matrix))
                    {
                        if (matrix[currentRow - 1, currentCol] == '<')
                        {
                            matrix[currentRow - 1, currentCol] = 'X';
                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow - 1, currentCol] == '>')
                        {
                            matrix[currentRow - 1, currentCol] = 'X';
                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (IndexExists(currentRow - 1, currentCol + 1, matrix))
                    {
                        if (matrix[currentRow - 1, currentCol + 1] == '<')
                        {
                            matrix[currentRow - 1, currentCol + 1] = 'X';
                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow - 1, currentCol + 1] == '>')
                        {
                            matrix[currentRow - 1, currentCol + 1] = 'X';
                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (IndexExists(currentRow, currentCol - 1, matrix))
                    {
                        if (matrix[currentRow, currentCol - 1] == '<')
                        {
                            matrix[currentRow, currentCol - 1] = 'X';
                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow, currentCol - 1] == '>')
                        {
                            matrix[currentRow, currentCol - 1] = 'X';
                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (IndexExists(currentRow, currentCol + 1, matrix))
                    {
                        if (matrix[currentRow, currentCol + 1] == '<')
                        {
                            matrix[currentRow, currentCol + 1] = 'X';
                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow, currentCol + 1] == '>')
                        {
                            matrix[currentRow, currentCol + 1] = 'X';
                            playerTwoShips--; 
                            shipsDestroyed++;
                        }
                    }

                    if (IndexExists(currentRow + 1, currentCol - 1, matrix))
                    {
                        if (matrix[currentRow + 1, currentCol - 1] == '<')
                        {
                            matrix[currentRow + 1, currentCol - 1] = 'X';
                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow + 1, currentCol - 1] == '>')
                        {
                            matrix[currentRow + 1, currentCol - 1] = 'X';
                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (IndexExists(currentRow + 1, currentCol, matrix))
                    {
                        if (matrix[currentRow + 1, currentCol] == '<')
                        {
                            matrix[currentRow + 1, currentCol] = 'X';
                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow + 1, currentCol] == '>')
                        {
                            matrix[currentRow + 1, currentCol] = 'X';
                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                    }

                    if (IndexExists(currentRow + 1, currentCol + 1, matrix))
                    {
                        if (matrix[currentRow + 1, currentCol + 1] == '<')
                        {
                            matrix[currentRow + 1, currentCol + 1] = 'X';
                            playerOneShips--; 
                            shipsDestroyed++;
                        }
                        else if (matrix[currentRow + 1, currentCol + 1] == '>')
                        {
                            matrix[currentRow + 1, currentCol + 1] = 'X';
                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                    }
                }

                if (playerOneShips == 0 || playerTwoShips == 0)
                {
                    break;
                }
            }

            if (playerOneShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! " +
                    $"{shipsDestroyed} ships have been sunk in the battle.");
            }
            else if (playerTwoShips == 0)
            {
                Console.WriteLine($"Player One has won the game! " +
                    $"{shipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! " +
                    $"Player One has {playerOneShips} ships left. " +
                    $"Player Two has {playerTwoShips} ships left.");
            }

        }

        static bool IndexExists(int row, int col, char[,] matrix)
        {
            if (row >= matrix.GetLength(0) || row < 0 ||
                col >= matrix.GetLength(1) || col < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
