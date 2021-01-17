using System;

namespace _04.Symbol_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSide = int.Parse(Console.ReadLine());

            char[,] matrix = new char[squareSide, squareSide];

            for (int row = 0; row < squareSide; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char input = char.Parse(Console.ReadLine());

            bool isFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = matrix[row, col];

                    if (currentChar == input)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            if (isFound)
            {
                return;
            }
            else
            {
                Console.WriteLine(input + " does not occur in the matrix");
            }
        }
    }
}
