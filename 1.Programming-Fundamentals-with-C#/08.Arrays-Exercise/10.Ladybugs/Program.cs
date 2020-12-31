using System;
using System.Linq;

namespace _10.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladybugIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < ladybugIndexes.Length; i++)
            {
                int index = ladybugIndexes[i];

                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputCommands = input.Split().ToArray();

                int ladybugLocation = int.Parse(inputCommands[0]);
                string direction = inputCommands[1];
                int flyingDistance = int.Parse(inputCommands[2]);
                int landingIndex = 0;

                if (ladybugLocation < 0 || ladybugLocation > field.Length - 1 || field[ladybugLocation] == 0)
                {
                    continue;
                }

                field[ladybugLocation] = 0;

                if (direction == "left")
                {
                    landingIndex = ladybugLocation - flyingDistance;

                    if (landingIndex < 0)
                    {
                        continue;
                    }

                    if (field[landingIndex] == 1)
                    {
                        while (field[landingIndex] == 1)
                        {
                            landingIndex -= flyingDistance;

                            if (landingIndex < 0)
                            {
                                break;
                            }
                        }
                    }

                    if (landingIndex >= 0 && landingIndex <= field.Length - 1)
                    {
                        field[landingIndex] = 1;
                    }

                }
                else if (direction == "right")
                {
                    landingIndex = ladybugLocation + flyingDistance;

                    if (landingIndex > field.Length - 1)
                    {
                        continue;
                    }

                    if (field[landingIndex] == 1)
                    {
                        while (field[landingIndex] == 1)
                        {
                            landingIndex += flyingDistance;

                            if (landingIndex > field.Length - 1)
                            {
                                break;
                            }
                        }
                    }

                    if (landingIndex >= 0 && landingIndex <= field.Length - 1)
                    {
                        field[landingIndex] = 1;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', field));
        }
    }
}
