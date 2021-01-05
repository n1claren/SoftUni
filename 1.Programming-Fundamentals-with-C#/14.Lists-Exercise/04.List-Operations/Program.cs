using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.List_Operations
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
                switch (command[0])
                {
                    case "add":

                        numbers.Add(int.Parse(command[1]));
                        break;

                    case "insert":

                        if (int.Parse(command[2]) >= 0 & int.Parse(command[2]) < numbers.Count)
                        {
                            numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "remove":

                        if (int.Parse(command[1]) >= 0 & int.Parse(command[1]) < numbers.Count)
                        {
                            numbers.RemoveAt(int.Parse(command[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "shift":

                        if (command[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                int temp = numbers[0];
                                numbers.RemoveAt(0);
                                numbers.Add(temp);
                            }
                        }

                        else if (command[1] == "right")
                        {
                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                int temp = numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);
                                numbers.Insert(0, temp);
                            }
                        }

                        break;
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