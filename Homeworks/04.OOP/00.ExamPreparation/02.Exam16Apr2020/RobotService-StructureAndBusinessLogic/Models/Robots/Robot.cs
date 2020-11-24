using System;

using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isBought;
        private bool isChipped;
        private bool isChecked;

        private Robot()
        {
            owner = "Service";
            isBought = false;
            isChipped = false;
            isChecked = false;
        }
        public Robot(string name, int energy, int happiness, int procedureTime)
            :this()
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }

        public int Happiness
        {
            get => happiness;
            set
            {
                if (0 > value || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                happiness = value;
            }
        }

        public int Energy
        {
            get => energy;
            set
            {
                if (0 > value || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                energy = value;
            }
        }

        public int ProcedureTime
        {
            get => procedureTime;
            set
            {
                procedureTime = value;
            }
        }

        public string Owner
        {
            get => owner;
            set
            {
                owner = value;
            }
        }

        public bool IsBought
        {
            get => isBought;
            set
            {
                isBought = value;
            }
        }

        public bool IsChipped
        {
            get => isChipped;
            set
            {
                isChipped = value;
            }
        }

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
            }
        }

        public override string ToString()
        => $" Robot type: {this.GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
    }
}
