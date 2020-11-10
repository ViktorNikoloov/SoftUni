using System;

using _05.FootballTeamGenerator.Common;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const string Stat_Exs_Msg = "{0} should be between 0 and 100.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(GlobalExeptions.Name_Exs_Msg));
                }

                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                IsAnExeptionAccured(value, nameof(this.Endurance));
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                IsAnExeptionAccured(value, nameof(this.Sprint));
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                IsAnExeptionAccured(value, nameof(this.Dribble));
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                IsAnExeptionAccured(value, nameof(this.Passing));
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                IsAnExeptionAccured(value, nameof(this.Shooting));
                shooting = value;
            }
        }

        public int SkillLevel
        => (int)Math.Round((double)(Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);


        private void IsAnExeptionAccured(double value, string stat)
        {
            if (0 > value || value > 100)
            {
                throw new ArgumentException(string.Format(Stat_Exs_Msg, stat));
            }
        }
    }
}
