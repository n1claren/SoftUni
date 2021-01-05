using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bombNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = bombNumbers[0];
            int power = bombNumbers[1];

            int bombIndex = numbers.IndexOf(bomb);

            while (bombIndex != -1)
            {
                int leftBlow = bombIndex - power;
                int rightBlow = bombIndex + power;

                if (leftBlow < 0)
                {
                    leftBlow = 0;
                }

                if (rightBlow > numbers.Count - 1)
                {
                    rightBlow = numbers.Count - 1;
                }


                numbers.RemoveRange(leftBlow, rightBlow - leftBlow + 1);

                bombIndex = numbers.IndexOf(bomb);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
