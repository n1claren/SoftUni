using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<string> que = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (que.Count > 0)
                    {
                        Console.WriteLine(que.Dequeue());
                    }
                }
                else
                {
                    que.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{que.Count} people remaining.");
        }
    }
}
