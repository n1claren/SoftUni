using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(
                Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());

            Queue<int> threads = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int taskChecker = tasks.Peek();

                if (taskChecker == taskToKill)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
                    break;
                }

                int currentTask = tasks.Pop();
                int currentThread = threads.Dequeue();

                if (currentThread >= currentTask)
                {
                    continue;
                }
                else
                {
                    tasks.Push(currentTask);
                }
            }

            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
