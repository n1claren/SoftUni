using System;

namespace _06.Triples_Of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        char A = (char)('a' + i);
                        char B = (char)('a' + k);
                        char C = (char)('a' + j);

                        Console.WriteLine($"{A}{B}{C}");
                    }
                }
            }
        }
    }
}
