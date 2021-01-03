using System;

namespace _07.NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintNumberMatrix(num);
        }

        static void PrintNumberMatrix(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int z = 0; z < number; z++)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
