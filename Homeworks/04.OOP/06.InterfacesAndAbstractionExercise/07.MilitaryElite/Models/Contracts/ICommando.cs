using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        public void AddMission(IMission mission);
    }
}
