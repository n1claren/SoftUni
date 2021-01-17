using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        { 
            int foodSupply = int.Parse(Console.ReadLine());

            int[] receivedOrders = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            Queue<int> orders = new Queue<int>(receivedOrders);

            int biggestOrder = orders.Max();

            Console.WriteLine(biggestOrder);

            while (orders.Count > 0)
            {
                int currentOrder = orders.Peek();

                if (currentOrder <= foodSupply)
                {
                    foodSupply -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Count > 0)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", orders));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
