using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Key_Revolver
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int bulletCost = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int earning = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> locksQue = new Queue<int>(locks);
            int shotBullets = 0;
            int barrelCount = 0;

            while (bulletStack.Any() && locksQue.Any())
            {

                if (bulletStack.Peek() <= locksQue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQue.Dequeue(); 
                    bulletStack.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletStack.Pop();
                }

                barrelCount++;

                if (barrelCount == barrelSize && bulletStack.Any())
                {
                    Console.WriteLine("Reloading!");
                    barrelCount = 0;
                }

                shotBullets++;
            }

            if (bulletStack.Count >= 0 && locksQue.Count == 0)
            {
                int earned = earning - (shotBullets * bulletCost);
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${earned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQue.Count}");
            }
        }
    }
}