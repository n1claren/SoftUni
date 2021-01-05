using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .ToLower()
                .Split()
                .ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "delete")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers.Contains(int.Parse(command[1])))
                        {
                            numbers.Remove(int.Parse(command[1]));
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (command[0] == "insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                command = Console.ReadLine()
                    .ToLower()
                    .Split()
                    .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
