using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] commands = command.Split();

                if (command.Contains("add"))
                {
                    for (int i = 1; i < commands.Length; i++)
                    {
                        stack.Push(int.Parse(commands[i]));
                    }
                }

                else if (command.Contains("remove"))
                {
                    int removeCount = int.Parse(commands[1]);

                    if (removeCount <= stack.Count)
                    {
                        for (int i = 0; i < removeCount; i++)
                        {
                            stack.Pop();
                        }
                    }

                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}
