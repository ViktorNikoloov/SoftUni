using System;

using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Models.Contracts;
using _07.MilitaryElite.Exceptions;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string corps)
            : base(firstName, lastName, id, salary)
        {
            Corps = TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        public Corps TryParseCorps(string corpsStr)
        {
            Corps corp;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corp);

            if (!parsed)
            {
                throw new InvalidCorpsException();

            }

            return corp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
            .AppendLine($"{base.ToString()}")
            .AppendLine($"Corps: {Corps.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
}
