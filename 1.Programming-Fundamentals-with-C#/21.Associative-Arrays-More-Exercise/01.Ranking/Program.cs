using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string contestsInput = Console.ReadLine();

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (contestsInput != "end of contests")
            {
                var inputArray = contestsInput.Split(":");

                contests.Add(inputArray[0], inputArray[1]);

                contestsInput = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> candidates = new 
                Dictionary<string, Dictionary<string, int>>();

            string submissionsInput = Console.ReadLine();

            while (submissionsInput != "end of submissions")
            {
                var inputArray = submissionsInput.Split("=>");

                string contest = inputArray[0];
                string password = inputArray[1];
                string candicate = inputArray[2];
                int points = int.Parse(inputArray[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        if (candidates.ContainsKey(candicate))
                        {
                            if (candidates[candicate].ContainsKey(contest))
                            {
                                if (candidates[candicate][contest] >= points)
                                {
                                    submissionsInput = Console.ReadLine();
                                    continue;
                                }
                                else
                                {
                                    candidates[candicate][contest] = points;
                                }
                            }
                            else
                            {
                                candidates[candicate].Add(contest, points);
                            }
                        }
                        else
                        {
                            Dictionary<string, int> temp = new Dictionary<string, int>();

                            temp.Add(contest, points);

                            candidates.Add(candicate, temp);
                        }
                    }
                    else
                    {
                        submissionsInput = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    submissionsInput = Console.ReadLine();
                    continue;
                }

                submissionsInput = Console.ReadLine();
            }

            string winner = candidates.OrderBy(x => x.Value.Values.Sum()).Last().Key;

            int winnerPoints = candidates.OrderBy(x => x.Value.Values.Sum()).Last().Value.Values.Sum();

            Console.WriteLine($"Best candidate is {winner} with total {winnerPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

            

        }
    }
}
