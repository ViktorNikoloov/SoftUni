using System;

using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Models.Contracts;
using _07.MilitaryElite.Exceptions;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string firstName, string lastName, string id, decimal salary, string corps)
            : base(firstName, lastName, id, salary)
        {
            Corps = TryParseCorps(corps);
        }

        public Corps Corps {get; private set;}

        public Corps TryParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();

            }

            return corps;
        }
    }
}
