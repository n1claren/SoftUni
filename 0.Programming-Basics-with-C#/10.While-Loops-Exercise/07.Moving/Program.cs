using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeSpaceWidth = int.Parse(Console.ReadLine());
            int freeSpaceLenght = int.Parse(Console.ReadLine());
            int freeSpaceHeight = int.Parse(Console.ReadLine());

            int freeSpace = freeSpaceHeight * freeSpaceLenght * freeSpaceWidth;

            string boxes = Console.ReadLine();

            int spaceNeeded = 0;
            int boxSum = 0;
            bool spaceFree = true;

            while (boxes != "Done")
            {
                freeSpace -= int.Parse(boxes);
                boxSum += int.Parse(boxes);

                if (freeSpace < 0)
                {
                    spaceNeeded = Math.Abs(freeSpace);
                    spaceFree = false;
                    break;
                }

                boxes = Console.ReadLine();
            }

            if (spaceFree)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }

            else
            {
                Console.WriteLine($"No more free space! You need {spaceNeeded} Cubic meters more.");
            }
        }
    }
}
