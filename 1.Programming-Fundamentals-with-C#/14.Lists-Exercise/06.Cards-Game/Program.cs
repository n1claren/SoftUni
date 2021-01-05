using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOneCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> playerTwoCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i <= Math.Min(playerOneCards.Count, playerTwoCards.Count); i++)
            {
                int tempOne = 0;
                int tempTwo = 0;

                if (Math.Min(playerOneCards.Count, playerTwoCards.Count) == 0)
                {
                    break;
                }

                if (playerOneCards[i] > playerTwoCards[i])
                {
                    tempOne = playerOneCards[i];
                    tempTwo = playerTwoCards[i];

                    playerOneCards.RemoveAt(i);
                    playerTwoCards.RemoveAt(i);

                    playerOneCards.Add(tempOne);
                    playerOneCards.Add(tempTwo);
                }

                else if (playerOneCards[i] < playerTwoCards[i])
                {
                    tempOne = playerOneCards[i];
                    tempTwo = playerTwoCards[i];

                    playerOneCards.RemoveAt(i);
                    playerTwoCards.RemoveAt(i);

                    playerTwoCards.Add(tempTwo);
                    playerTwoCards.Add(tempOne);
                }

                else if (playerOneCards[i] == playerTwoCards[i])
                {
                    playerOneCards.RemoveAt(i);
                    playerTwoCards.RemoveAt(i);
                }

                i--;
            }

            if (playerOneCards.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwoCards.Sum()}");
            }

            else
            {
                Console.WriteLine($"First player wins! Sum: {playerOneCards.Sum()}");
            }
        }
    }
}