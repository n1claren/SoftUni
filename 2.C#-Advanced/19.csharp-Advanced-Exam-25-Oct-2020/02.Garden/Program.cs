using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenDimensions = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            int gardenRows = gardenDimensions[0];
            int gardenCols = gardenDimensions[1];

            int[,] garden = new int[gardenRows, gardenCols];

            for (int rows = 0; rows < gardenRows; rows++)
            {
                for (int cols = 0; cols < gardenCols; cols++)
                {
                    garden[rows, cols] = 0;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] plantCoordinates = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int plantRow = plantCoordinates[0];
                int plantCol = plantCoordinates[1];

                if (!IndexExists(plantRow, plantCol, garden))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int row = 0; row < garden.GetLength(0); row++)
                {
                    for (int col = 0; col < garden.GetLength(1); col++)
                    {
                        if (row == plantRow || col == plantCol)
                        {
                            garden[row, col]++;
                        }
                    }
                }
            }

            for (int rows = 0; rows < garden.GetLength(0); rows++)
            {
                for (int cols = 0; cols < garden.GetLength(1); cols++)
                {
                    Console.Write(garden[rows, cols] + " ");
                }

                Console.WriteLine();
            }
        }

        static bool IndexExists(int row, int col, int[,] matrix)
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
