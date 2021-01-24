using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string participantsNames = Console.ReadLine();

            Dictionary<string, int> raceStats = new Dictionary<string, int>();

            string[] participants = participantsNames.Split(", ");

            for (int i = 0; i < participants.Length; i++)
            {
                raceStats.Add(participants[i], 0);
            }

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var name = new String(input.Where(Char.IsLetter).ToArray());

                var distanceString = new String(input.Where(Char.IsDigit).ToArray());

                int distance = 0;

                for (int i = 0; i < distanceString.Length; i++)
                {
                    distance += int.Parse(distanceString[i].ToString());
                }

                if (raceStats.ContainsKey(name))
                {
                    raceStats[name] += distance;
                }

                input = Console.ReadLine();
            }

            var placement = raceStats.OrderByDescending(x => x.Value);

            List<string> top3 = new List<string>();

            foreach (var participant in placement)
            {
                top3.Add(participant.Key);
            }

            Console.WriteLine($"1st place: {top3[0]}");
            Console.WriteLine($"2nd place: {top3[1]}");
            Console.WriteLine($"3rd place: {top3[2]}");
        }
    }
}