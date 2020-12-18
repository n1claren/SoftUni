using System;

namespace ForLoopsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;

            for (int i = 1; i <= n; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
