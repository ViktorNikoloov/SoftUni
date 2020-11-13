using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        public void AddRepair(IRepair repair);
    }
}
