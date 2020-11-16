using _07.MilitaryElite.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, Contracts.ILieutenantGeneral
    {
        ICollection<ISoldier> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates
            => (IReadOnlyCollection<ISoldier>)privates;

        public void AddPrivate(ISoldier @private)
        => privates.Add(@private);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}")
                .AppendLine("Privates:");

            foreach (var @private in privates)
            {
                sb.AppendLine("  " + @private.ToString());
            }

            return sb.ToString().TrimEnd();

        }
    }
}
