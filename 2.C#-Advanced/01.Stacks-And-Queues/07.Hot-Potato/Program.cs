using System;
using System.Collections.Generic;

namespace _07.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();

            int hotPotatoTosses = int.Parse(Console.ReadLine());

            Queue<string> hotPotatoGame = new Queue<string>(kids);

            int tossCounter = 0;

            while (hotPotatoGame.Count > 1)
            {
                string kidOut = hotPotatoGame.Dequeue();
                tossCounter++;
                
                if (tossCounter == hotPotatoTosses)
                {
                    Console.WriteLine("Removed " + kidOut);
                    tossCounter = 0;
                }
                else
                {
                    hotPotatoGame.Enqueue(kidOut);
                }
            }

            Console.WriteLine("Last is " + hotPotatoGame.Dequeue());
        }
    }
}
