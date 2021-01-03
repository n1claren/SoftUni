using System;
using System.Linq;

namespace _11.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string manipulationCommand = string.Empty;

            while ((manipulationCommand = Console.ReadLine().ToLower()) != "end")
            {
                string[] command = manipulationCommand.Split();

                if (command[0] == "exchange")
                {
                    int indexChecker = int.Parse(command[1]);

                    if (indexChecker < 0 || indexChecker > array.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    else
                    {
                        array = ExchangeIndex(array, int.Parse(command[1]));
                    }
                }

                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        if (MaxEven(array) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(MaxEven(array));
                    }

                    else if (command[1] == "odd")
                    {
                        if (MaxOdd(array) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(MaxOdd(array));
                    }

                }

                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        if (MinEven(array) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(MinEven(array));
                    }

                    else if (command[1] == "odd")
                    {
                        if (MinOdd(array) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(MinOdd(array));
                    }
                }

                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (command[2] == "even")
                    {
                        FirstEven(array, count);
                    }

                    else if (command[2] == "odd")
                    {
                        FirstOdd(array, count);
                    }
                }

                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (command[2] == "even")
                    {
                        LastEven(array, count);
                    }

                    else if (command[2] == "odd")
                    {
                        LastOdd(array, count);
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        static int[] ExchangeIndex(int[] array, int index)
        {
            int[] firstHalf = array.Take(index + 1).ToArray();
            int[] secondHalf = array.Skip(index + 1).ToArray();

            int[] exchangedArray = secondHalf.Concat(firstHalf).ToArray();

            array = exchangedArray;
            return array;
        }

        static int MaxEven(int[] array)
        {
            int maxEven = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] >= maxEven)
                    {
                        maxEven = array[i];
                        index = i;
                    }
                }
            }

            return index;
        }

        static int MaxOdd(int[] array)
        {
            int maxOdd = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] >= maxOdd)
                    {
                        maxOdd = array[i];
                        index = i;
                    }
                }
            }

            return index;
        }

        static int MinEven(int[] array)
        {
            int minEven = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] <= minEven)
                    {
                        minEven = array[i];
                        index = i;
                    }
                }

            }

            return index;
        }

        static int MinOdd(int[] array)
        {
            int minOdd = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] <= minOdd)
                    {
                        minOdd = array[i];
                        index = i;
                    }
                }

            }

            return index;
        }

        static void FirstEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }


            }

            var numbersArray = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }

            else
            {
                Console.WriteLine("[" + string.Join(", ", numbersArray) + "]");
            }

        }

        static void FirstOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }


            }

            var numbersArray = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }

            else
            {
                Console.WriteLine("[" + string.Join(", ", numbersArray) + "]");
            }

        }

        static void LastEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var numbersArray = numbers
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }

            else
            {
                Console.WriteLine("[" + string.Join(", ", numbersArray) + "]");
            }
        }

        static void LastOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var numbersArray = numbers
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }

            else
            {
                Console.WriteLine("[" + string.Join(", ", numbersArray) + "]");
            }
        }
    }
}
