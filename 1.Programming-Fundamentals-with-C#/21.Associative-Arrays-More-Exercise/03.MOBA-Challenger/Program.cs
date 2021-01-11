using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new 
                Dictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "Season end")
            {
                List<string> SplitedNewPlayers = new List<string>();

                List<string> PlayerVSplayer = new List<string>();

                string player;

                string position;

                int skill = 0;

                if (input.Contains("->"))
                {
                    var newPLayers = input.Split(" -> ").ToList();

                    player = newPLayers[0];

                    position = newPLayers[1];

                    skill = int.Parse(newPLayers[2]);

                    if (!players.ContainsKey(player))
                    {
                        players.Add(player, new Dictionary<string, int>());
                    }

                    if (!players[player].ContainsKey(position))
                    {
                        players[player].Add(position, 0);
                    }

                    if (players[player][position] <= skill)
                    {
                        players[player][position] = skill;

                    }
                }

                else
                {
                    var PVP = input.Split(" vs ").ToList();

                    string playerOne = PVP[0];

                    string playerTwo = PVP[1];

                    if (!players.ContainsKey(playerOne) || !players.ContainsKey(playerTwo))
                    {
                        continue;
                    }

                    bool commonPosition = false;

                    foreach (var item in players[playerOne])
                    {
                        if (players[playerTwo].ContainsKey(item.Key))
                        {
                            commonPosition = true;
                        }
                    }

                    int totalSkillsOne = 0;
                    int totalSkillsTwo = 0;

                    if (commonPosition)
                    {
                        totalSkillsOne = players[playerOne].Values.Sum();

                        totalSkillsTwo = players[playerTwo].Values.Sum();

                        if (totalSkillsOne > totalSkillsTwo)
                        {
                            players.Remove(playerTwo);
                        }

                        else if (totalSkillsTwo > totalSkillsOne)
                        {
                            players.Remove(playerOne);
                        }
                    }
                }
            }

            foreach (var player in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var men in player.Value.OrderByDescending(x => x.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"- {men.Key} <::> {men.Value}");
                }
            }
        }
    }
}