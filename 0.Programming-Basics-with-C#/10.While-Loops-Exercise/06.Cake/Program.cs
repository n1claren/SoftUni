using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLenght = int.Parse(Console.ReadLine());

            string pieces = Console.ReadLine();

            int cakeSize = cakeLenght * cakeWidth;

            int piecesTaken = 0;
            bool isEnough = true;


            while (pieces != "STOP")
            {
                cakeSize -= int.Parse(pieces);
                piecesTaken += int.Parse(pieces);

                if (cakeSize < 0)
                {
                    isEnough = false;
                    cakeSize = cakeLenght * cakeWidth;
                    break;
                }

                pieces = Console.ReadLine();

            }

            if (isEnough)
            {
                cakeSize = cakeLenght * cakeWidth;
                Console.WriteLine($"{cakeSize - piecesTaken} pieces are left.");
            }

            else
            {
                Console.WriteLine($"No more cake left! You need {piecesTaken - cakeSize} pieces more.");
            }
        }
    }
}
