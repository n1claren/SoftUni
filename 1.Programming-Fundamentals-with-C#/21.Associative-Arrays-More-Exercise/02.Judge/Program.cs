using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new 
                Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> topIndividuals = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputArray = input.Split(" -> ");

                string name = inputArray[0];

                string contest = inputArray[1];

                int points = int.Parse(inputArray[2]);

                if (!contests.ContainsKey(contest))
                {
                    if (!topIndividuals.ContainsKey(name))
                    {
                        contests[contest] = new Dictionary<string, int>();

                        contests[contest].Add(name, points);

                        topIndividuals[name] = points;
                    }

                    else if (topIndividuals.ContainsKey(name))
                    {
                        contests[contest] = new Dictionary<string, int>();

                        contests[contest].Add(name, points);

                        topIndividuals[name] += points;
                    }
                }

                else if (contests.ContainsKey(contest))
                {
                    if (!topIndividuals.ContainsKey(name))
                    {
                        contests[contest].Add(name, points);

                        topIndividuals[name] = points;
                    }

                    else if (topIndividuals.ContainsKey(name))
                    {
                        bool alreadyExists = false;

                        foreach (var kvp in contests[contest])
                        {
                            string currentUsername = kvp.Key;

                            int currentPoints = kvp.Value;

                            if (currentUsername == name)
                            {
                                alreadyExists = true;

                                if (points > currentPoints)
                                {
                                    contests[contest][name] = points;

                                    topIndividuals[name] -= currentPoints;

                                    topIndividuals[name] += points;

                                    alreadyExists = true;

                                    break;
                                }
                            }
                        }

                        if (!alreadyExists)
                        {
                            contests[contest].Add(name, points);

                            topIndividuals[name] += points;
                        }
                    }
                }
            }


            foreach (var kvp in contests)
            {
                string contest = kvp.Key;

                var usernameAndPointsDictionary = kvp.Value;

                int k = 0;

                Console.WriteLine($"{contest}: {contests[contest].Count()} participants");

                foreach (var participant in contests[contest].OrderByDescending(x => x.Value)
                                                                                        .ThenBy(x => x.Key))
                {
                    k++;

                    string name = participant.Key;

                    int points = participant.Value;

                    Console.WriteLine($"{k}. {name} <::> {points}");

                }
            }

            Console.WriteLine("Individual standings:");

            int i = 0;

            foreach (var kvp in topIndividuals.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                i++;

                string username = kvp.Key;

                int totalPoints = kvp.Value;

                Console.WriteLine($"{i}. {username} -> {totalPoints}");
            }

        }
    }
}
