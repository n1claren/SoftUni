using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.Star_Enigma
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> planetActions = new Dictionary<string, List<string>>();

            planetActions.Add("Attacked", new List<string>());
            planetActions.Add("Destroyed", new List<string>());

            StringBuilder firstStageDecrypt = new StringBuilder();

            string pattern = @"@(?<planet>[A-Za-z]+)([^@\-!:>])*:(?<population>[0-9]+)([^@\-!:>])*!(?<attack_type>[AD])!([^@\-!:>])*->(?<soldier_count>[0-9]+)";

            for (int i = 0; i < n; i++)
            {
                string messageEncrypted = Console.ReadLine();

                int key = CountCryptoKey(messageEncrypted);

                string firstStage = DecryptFirstStage(messageEncrypted, key).ToString();

                Match decrypted = Regex.Match(firstStage, pattern);

                if (decrypted.Success)
                {
                    string planetName = decrypted.Groups["planet"].Value;
                    string attackType = decrypted.Groups["attack_type"].Value;

                    if (attackType == "A")
                    {
                        planetActions["Attacked"].Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        planetActions["Destroyed"].Add(planetName);
                    }
                }
            }

            foreach (var planet in planetActions)
            {
                Console.WriteLine($"{planet.Key} planets: {planet.Value.Count}");

                foreach (var planets in planet.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planets}");
                }
            }
        }
        static StringBuilder DecryptFirstStage(string message, int key)
        {
            StringBuilder firstStageDecrypt = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                firstStageDecrypt.Append((char)(message[i] - key));
            }

            return firstStageDecrypt;
        }
        static int CountCryptoKey(string message)
        {
            string pattern = @"[STARstar]";

            MatchCollection lettersKey = Regex.Matches(message, pattern);

            return lettersKey.Count();
        }
    }
}