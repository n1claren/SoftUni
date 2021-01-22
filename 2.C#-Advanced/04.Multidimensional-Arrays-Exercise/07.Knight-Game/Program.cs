using System;

namespace _07.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSide = int.Parse(Console.ReadLine());

            char[,] matrix = new char[squareSide, squareSide];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int currentKnightInDanger = 0;
            int maxKnightsInDanger = 0;
            int mostDangerRow = 0;
            int mostDangerCol = 0;
            int knightsRemoved = 0;

            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col].Equals('K'))
                        {
                            if (ElementExists(row - 2, col - 1, matrix))
                            {
                                if (matrix[row - 2, col - 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }

                            if (ElementExists(row - 2, col + 1, matrix))
                            {
                                if (matrix[row - 2, col + 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }

                            if (ElementExists(row + 2, col - 1, matrix))
                            {
                                if (matrix[row + 2, col - 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }

                            if (ElementExists(row + 2, col + 1, matrix))
                            {
                                if (matrix[row + 2, col + 1].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }

                            if (ElementExists(row - 1, col - 2, matrix))
                            {
                                if (matrix[row - 1, col - 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }

                            if (ElementExists(row - 1, col + 2, matrix))
                            {
                                if (matrix[row - 1, col + 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }

                            if (ElementExists(row + 1, col - 2, matrix))
                            {
                                if (matrix[row + 1, col - 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }

                            if (ElementExists(row + 1, col + 2, matrix))
                            {
                                if (matrix[row + 1, col + 2].Equals('K'))
                                {
                                    currentKnightInDanger++;
                                }
                            }
                        }

                        if (currentKnightInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightInDanger;
                            mostDangerRow = row;
                            mostDangerCol = col;
                        }

                        currentKnightInDanger = 0;
                    }
                }

                if (maxKnightsInDanger != 0)
                {
                    matrix[mostDangerRow, mostDangerCol] = 'O';
                    knightsRemoved++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(knightsRemoved);
                    return;
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
    }
}
