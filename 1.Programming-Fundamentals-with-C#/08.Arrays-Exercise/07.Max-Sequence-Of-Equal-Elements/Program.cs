using System;
using System.Linq;

namespace _07.Max_Sequence_Of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int streak = 1;
            int bestStreak = 0;

            int streakStart = 0;
            int bestStreakStart = 0;


            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    streak++;
                }
                else
                {
                    streak = 1;
                    streakStart = i;
                }

                if (streak > bestStreak)
                {
                    bestStreak = streak;
                    bestStreakStart = streakStart;
                }
            }

            for (int i = bestStreakStart; i < bestStreakStart + bestStreak; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
