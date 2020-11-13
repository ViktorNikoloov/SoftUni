using _07.MilitaryElite.Models.Contracts;
using System.Collections.Generic;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(string firstName, string lastName, string id, decimal salary, string corps) 
            : base(firstName, lastName, id, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions
            => (IReadOnlyCollection<IMission>)missions;

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

    }
}
