using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (input[2] == "going!")
                {
                    if (guestList.Contains(input[0]))
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(input[0]);
                    }
                }

                if (input[2] == "not")
                {
                    if (guestList.Contains(input[0]))
                    {
                        guestList.Remove(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }


            }

            for (int i = 0; i < guestList.Count; i++)
            {
                Console.WriteLine(guestList[i]);
            }


        }
    }
}