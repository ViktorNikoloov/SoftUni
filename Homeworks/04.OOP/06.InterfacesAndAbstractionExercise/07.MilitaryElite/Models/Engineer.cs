using System.Collections.Generic;

using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(string firstName, string lastName, string id, decimal salary, string corps) 
            : base(firstName, lastName, id, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs
            => (IReadOnlyCollection<IRepair>)repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }
    }
}
