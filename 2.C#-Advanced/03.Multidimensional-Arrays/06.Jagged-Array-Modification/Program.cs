using System;
using System.Linq;

namespace _06.Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSide = int.Parse(Console.ReadLine());

            int[][] jagged = new int[squareSide][];

            for (int row = 0; row < squareSide; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splittedCommand = command.Split();

                if (splittedCommand[0] == "Add")
                {
                    int row = int.Parse(splittedCommand[1]);
                    int col = int.Parse(splittedCommand[2]);
                    int value = int.Parse(splittedCommand[3]);

                    if (elementExists(row, col, squareSide))
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (splittedCommand[0] == "Subtract")
                {
                    int row = int.Parse(splittedCommand[1]);
                    int col = int.Parse(splittedCommand[2]);
                    int value = int.Parse(splittedCommand[3]);

                    if (elementExists(row, col, squareSide))
                    {
                        jagged[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            for (int i = 0; i < squareSide; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }

        static bool elementExists(int row, int col, int squareSide)
        {
            if (row >= 0 && col >= 0 && row < squareSide && col < squareSide)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
