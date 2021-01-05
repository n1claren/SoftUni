using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Pokemon_Dont_Go
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int removeNumberOne = numbers[0];

                    sum += removeNumberOne;

                    numbers[0] = numbers[numbers.Count - 1];

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= removeNumberOne)
                        {
                            numbers[i] += removeNumberOne;
                        }
                        else
                        {
                            numbers[i] -= removeNumberOne;
                        }
                    }
                }

                else if (index >= numbers.Count)
                {
                    int removeNumberTwo = numbers[numbers.Count - 1];

                    sum += removeNumberTwo;

                    numbers[numbers.Count - 1] = numbers[0];

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= removeNumberTwo)
                        {
                            numbers[i] += removeNumberTwo;
                        }
                        else
                        {
                            numbers[i] -= removeNumberTwo;
                        }
                    }
                }

                else
                {
                    int removeNumberThree = numbers[index];

                    sum += removeNumberThree;

                    numbers.RemoveAt(index);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= removeNumberThree)
                        {
                            numbers[i] += removeNumberThree;
                        }
                        else
                        {
                            numbers[i] -= removeNumberThree;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}