using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Treasure_Finder
{
    class Program
    {
        static void Main()
        {
            var key = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int currentPossition = 0;

            string sequence;

            string regex = @"&(?<type>.+)&[^<]*<(?<coord>.+)>";

            while ((sequence = Console.ReadLine()) != "find")
            {
                int keyLength = key.Count;

                int sequenceLength = sequence.Length;

                StringBuilder sb = new StringBuilder();

                for (int i = keyLength; i < sequenceLength; i++)
                {
                    key.Add(key[currentPossition]);

                    currentPossition++;
                }

                for (int i = 0; i < sequenceLength; i++)
                {
                    sb.Append((char)(sequence[i] - key[i]));
                }

                Match match = Regex.Match(sb.ToString(), regex);

                if (match.Success)
                {
                    string type = match.Groups["type"].Value;

                    string coord = match.Groups["coord"].Value;

                    Console.WriteLine($"Found {type} at {coord}");
                }
            }
        }
    }
}