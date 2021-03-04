using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Football_Team_Generator
{
    public class Stats
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private const string INVALID_STAT_MSG = "{0} should be between {1} and {2}.";

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;

            private set
            {
                ValidateStats(nameof(Endurance), value);

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;

            private set
            {
                ValidateStats(nameof(Sprint), value);

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;

            private set
            {
                ValidateStats(nameof(Dribble), value);

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;

            private set
            {
                ValidateStats(nameof(Passing), value);

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;

            private set
            {
                ValidateStats(nameof(Shooting), value);

                shooting = value;
            }
        }

        private void ValidateStats(string name, int value)
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException
                    (String.Format(INVALID_STAT_MSG, name, MIN_STAT, MAX_STAT));
            }
        }

        public double AverageStats => 
            Math.Ceiling((double)(Endurance + Sprint + Dribble + Passing + Shooting) / 5);
    }
}
