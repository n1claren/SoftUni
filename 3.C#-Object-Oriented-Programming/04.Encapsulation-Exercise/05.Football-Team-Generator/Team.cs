using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.Football_Team_Generator
{
    public class Team
    {
        public const string INVALID_NAME_MSG = "A name should not be empty.";
        public const string INVALID_PLAYER_REMOVE_MSG = "Player {0} is not in {1} team.";

        private string name;
        private readonly ICollection<Player> players;

        public Team(string name)
        {
            Name = name;

            players = new List<Player>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(INVALID_NAME_MSG);
                }

                name = value;
            }
        }

        public double Rating => 
            players.Count > 0 ? Math.Ceiling(players.Average(p => p.OverallSkills)) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException
                    (String.Format(INVALID_PLAYER_REMOVE_MSG, playerName, Name));
            }

            players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
