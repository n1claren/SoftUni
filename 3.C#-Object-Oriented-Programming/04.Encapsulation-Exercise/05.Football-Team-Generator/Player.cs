using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Football_Team_Generator
{
    public class Player
    {
        public const string INVALID_NAME_MSG = "A name should not be empty.";

        private string name;

        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
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

        public Stats Stats { get; set; }

        public double OverallSkills => Stats.AverageStats;
    }
}
