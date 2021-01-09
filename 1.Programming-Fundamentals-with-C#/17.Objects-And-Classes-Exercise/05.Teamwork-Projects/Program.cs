using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                var teamCreation = Console.ReadLine().Split("-").ToList();

                string teamName = teamCreation[1];
                string teamCreator = teamCreation[0];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x => x.Creator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }

                Team tempTeam = new Team();

                tempTeam.Creator = teamCreator;
                tempTeam.TeamName = teamName;
                tempTeam.Members = new List<string>();

                Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");

                teams.Add(tempTeam);
            }

            string teamsMovement = string.Empty;

            while ((teamsMovement = Console.ReadLine()) != "end of assignment")
            {
                var movement = teamsMovement.Split("->").ToList();

                string memberToJoin = movement[0];
                string teamToJoin = movement[1];

                if (!teams.Any(x => x.TeamName == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.Creator == memberToJoin) || teams.Any(x => x.Members.Contains(memberToJoin)))
                {
                    Console.WriteLine($"Member {memberToJoin} cannot join team {teamToJoin}!");
                    continue;
                }

                int index = teams.FindIndex(x => x.TeamName == teamToJoin);

                teams[index].Members.Add(memberToJoin);
            }

            List<Team> sortedTeams = teams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            for (int i = 0; i < sortedTeams.Count; i++)
            {
                sortedTeams[i].Members.Sort();
            }

            foreach (var team in sortedTeams)
            {
                if (team.Members.Count == 0)
                {
                    continue;
                }

                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                for (int i = 0; i < team.Members.Count; i++)
                {
                    Console.WriteLine($"-- {team.Members[i]}");
                }

            }

            List<Team> teamsToDisband = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
