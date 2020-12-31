using System;
using System.Linq;

namespace _09.Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[n];

            string input = Console.ReadLine();

            int bestLenght = 1;
            int bestStartIndex = 0;
            int bestSequenceSum = 0;
            int counter = 0;
            int bestSequenceNumber = 0;
            int[] bestSequence = new int[n];

            while (input != "Clone them!")
            {
                sequence = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                counter++;

                int lenght = 1;
                int bestCurrentLenght = 1;
                int streakStart = 0;
                int sequenceSum = 0;

                for (int i = 0; i < sequence.Length - 1; i++)
                {

                    if (sequence[i] == sequence[i + 1])
                    {
                        lenght++;
                    }
                    else
                    {
                        lenght = 1;
                    }

                    if (bestCurrentLenght < lenght)
                    {
                        bestCurrentLenght = lenght;
                        streakStart = i;
                    }
                }

                for (int i = 0; i < sequence.Length; i++)
                {
                    sequenceSum += sequence[i];
                }

                if (bestLenght < bestCurrentLenght)
                {
                    bestLenght = bestCurrentLenght;
                    bestStartIndex = streakStart;
                    bestSequenceSum = sequenceSum;
                    bestSequenceNumber = counter;
                    bestSequence = sequence.ToArray();
                }
                else if (bestLenght == bestCurrentLenght)
                {
                    if (streakStart < bestStartIndex)
                    {
                        bestLenght = bestCurrentLenght;
                        bestStartIndex = streakStart;
                        bestSequenceSum = sequenceSum;
                        bestSequenceNumber = counter;
                        bestSequence = sequence.ToArray();

                    }
                    else if (streakStart == bestStartIndex)
                    {
                        if (sequenceSum > bestSequenceSum)
                        {
                            bestLenght = bestCurrentLenght;
                            bestStartIndex = streakStart;
                            bestSequenceSum = sequenceSum;
                            bestSequenceNumber = counter;
                            bestSequence = sequence.ToArray();
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceNumber} with sum: {bestSequenceSum}.");

            Console.WriteLine(string.Join(' ', bestSequence));
        }
    }
}
