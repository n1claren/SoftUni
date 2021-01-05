using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex < 0 || startIndex > input.Count - 1)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= input.Count)
                    {
                        endIndex = input.Count - 1;
                    }

                    string mergedElements = string.Empty;
                    int removeRange = 0;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        mergedElements += input[i];
                        removeRange++;
                    }

                    input.RemoveRange(startIndex, removeRange);
                    input.Insert(startIndex, mergedElements);
                }

                if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int splitParts = int.Parse(command[2]);

                    if (input[index].Length % splitParts == 0)
                    {
                        List<string> temp = new List<string>();

                        int counter = 0;

                        int splitLenght = input[index].Length / splitParts;

                        string tempString = string.Empty;

                        for (int i = 0; i < input[index].Length; i++)
                        {
                            tempString += input[index][i];
                            counter++;

                            if (counter == splitLenght)
                            {
                                temp.Add(tempString);
                                counter = 0;
                                tempString = string.Empty;
                            }
                        }

                        input.RemoveAt(index);

                        for (int i = temp.Count - 1; i >= 0; i--)
                        {
                            input.Insert(index, temp[i]);
                        }
                    }

                    else
                    {
                        List<string> temp = new List<string>();

                        int counter = 0;

                        int splitLenght = input[index].Length / splitParts;

                        string tempString = string.Empty;

                        for (int i = 0; i < input[index].Length; i++)
                        {
                            tempString += input[index][i];
                            counter++;

                            if (counter == splitLenght && temp.Count < splitParts)
                            {
                                temp.Add(tempString);
                                counter = 0;
                                tempString = string.Empty;
                            }
                        }

                        if (tempString != "")
                        {
                            temp[temp.Count - 1] += tempString;
                        }

                        input.RemoveAt(index);

                        for (int i = temp.Count - 1; i >= 0; i--)
                        {
                            input.Insert(index, temp[i]);
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', input));

        }
    }
}
