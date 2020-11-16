using System;

using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Models.Contracts;
using _07.MilitaryElite.Exceptions;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = TryParseCorps(corps);
        }

        public Corps Corps {get; private set;}

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
    }
}
