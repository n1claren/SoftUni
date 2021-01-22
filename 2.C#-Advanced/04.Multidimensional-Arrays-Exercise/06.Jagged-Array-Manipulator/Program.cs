using System;
using System.Linq;

namespace _06.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagged = new double[rows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row+1].Length)
                {
                    for (int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] *= 2;
                        jagged[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] /= 2;
                    }

                    for (int i = 0; i < jagged[row+1].Length; i++)
                    {
                        jagged[row + 1][i] /= 2;
                    }
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commands = command.Split();

                int rowIndex = int.Parse(commands[1]);
                int colIndex = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (rowIndex >= jagged.Length || rowIndex < 0 ||
                    colIndex >= jagged[rowIndex].Length || colIndex < 0)
                {
                    continue;
                }

                if (commands[0] == "Add")
                {
                    jagged[rowIndex][colIndex] += value;
                }
                else if (commands[0] == "Subtract")
                {
                    jagged[rowIndex][colIndex] -= value;
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
