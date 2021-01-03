using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToList();

            string[] command = Console.ReadLine().ToLower().Split().ToArray();

            bool isChanged = false;

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        numbers.Add(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "remove":
                        numbers.Remove(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "removeat":
                        numbers.RemoveAt(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "contains":

                        if (numbers.Contains(int.Parse(command[1])))
                        {
                            Console.WriteLine("Yes");
                        }

                        else
                        {
                            Console.WriteLine("No such number");
                        }

                        break;

                    case "printeven":

                        List<int> evenNumbers = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                evenNumbers.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(' ', evenNumbers));

                        break;

                    case "printodd":
                        List<int> oddNumbers = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                            {
                                oddNumbers.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(' ', oddNumbers));

                        break;

                    case "getsum":
                        Console.WriteLine(numbers.Sum());
                        break;

                    case "filter":

                        int num = int.Parse(command[2]);

                        switch (command[1])
                        {
                            case ">":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n > num)));
                                break;

                            case "<":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n < num)));
                                break;

                            case ">=":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n >= num)));
                                break;

                            case "<=":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n <= num)));
                                break;

                        }

                        break;

                }

                command = Console.ReadLine().ToLower().Split().ToArray();
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }

        }
    }
}