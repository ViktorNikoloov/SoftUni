using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(string firstName, string lastName, int id, decimal salary, string corps) : base(firstName, lastName, id, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs
            => (IReadOnlyCollection<IRepair>)repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{base.ToString()}")
                .AppendLine("Repairs:");

            foreach (var repair in repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
