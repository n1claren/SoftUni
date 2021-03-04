using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Football_Team_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            // DISCLAIMER: This code is not finished and has bugs.
            // The Zero tests @ Judge pass, but the others do not.
            // I am already 4 hours over the amount of time i set out to code today.
            // I have to cram everything i had planned for today in 3 hours coz of running late coding.
            // Might finish this problem later, might not.
            // P.S. Judge is stupid
            // Have Fun =) 

            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(';');

                if (command[0] == "Team")
                {
                    Team team = new Team(command[1]);
                    teams.Add(team);
                }

                try
                {
                    if (command[0] == "Add")
                    {
                        string playerTeam = command[1];
                        string playerName = command[2];

                        TeamExists(playerTeam, teams);

                        Stats stats = GetStats(command.Skip(3).ToList());

                        Player player = new Player(playerName, stats);

                        Team team = teams.First(t => t.Name == playerTeam);

                        team.AddPlayer(player);
                    }
                }
                catch (Exception ex1)
                {
                    Console.WriteLine(ex1.Message);
                }

                try
                {
                    if (command[0] == "Remove")
                    {
                        string playerTeam = command[1];
                        string playerName = command[2];

                        TeamExists(playerTeam, teams);

                        Team team = teams.First(t => t.Name == playerTeam);

                        team.RemovePlayer(playerName);
                    }
                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message);
                }



                if (command[0] == "Rating")
                {
                    string teamName = command[1];

                    TeamExists(teamName, teams);

                    Team team = teams.First(t => t.Name == teamName);

                    Console.WriteLine(team);
                }
            }
        }
        public static Stats GetStats(List<string> statsArgs)
        {
            int endurance = int.Parse(statsArgs[0]);
            int speed = int.Parse(statsArgs[1]);
            int dribble = int.Parse(statsArgs[2]);
            int passing = int.Parse(statsArgs[3]);
            int shooting = int.Parse(statsArgs[4]);

            Stats stats = new Stats(endurance, speed, dribble, passing, shooting);

            return stats;
        }

        public static void TeamExists(string teamName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }
        }
    }
}
