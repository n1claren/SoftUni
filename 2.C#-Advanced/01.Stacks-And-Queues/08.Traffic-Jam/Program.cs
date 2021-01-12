using System;
using System.Collections.Generic;

namespace _08.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenCarPassing = int.Parse(Console.ReadLine());

            Queue<string> carQue = new Queue<string>();

            string input;
            int passCounter = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < greenCarPassing; i++)
                    {
                        if (carQue.Count > 0)
                        {
                            Console.WriteLine(carQue.Dequeue() + " passed!");
                            passCounter++;
                        }
                    }
                }
                else
                {
                    carQue.Enqueue(input);
                }
            }

            Console.WriteLine(passCounter + " cars passed the crossroads.");
        }
    }
}
