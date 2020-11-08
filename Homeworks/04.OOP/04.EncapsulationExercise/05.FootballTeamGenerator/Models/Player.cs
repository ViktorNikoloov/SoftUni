using System;

using _05.FootballTeamGenerator.Common;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const string Stat_Exs_Msg = "{0} should be between 0 and 100.";

        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
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

        public double Endurance
        {
            get => endurance;
            private set
            {
                IsAnExeptionAccured(value, "Endurance");
                endurance = value;
            }
        }

        public double Sprint
        {
            get => sprint;
            private set
            {
                IsAnExeptionAccured(value, "Sprint");
                sprint = value;
            }
        }

        public double Dribble
        {
            get => dribble;
            private set
            {
                IsAnExeptionAccured(value, "Dribble");
                dribble = value;
            }
        }

        public double Passing
        {
            get => passing;
            private set
            {
                IsAnExeptionAccured(value, "Passing");
                passing = value;
            }
        }

        public double Shooting
        {
            get => shooting;
            private set
            {
                IsAnExeptionAccured(value, "Shooting");
                shooting = value;
            }
        }

        public double SkillLevel
        => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;


        private void IsAnExeptionAccured(double value, string stat)
        {
            if (0 > value || value > 100)
            {
                throw new ArgumentException(string.Format(Stat_Exs_Msg, stat));
            }
        }
    }
}
