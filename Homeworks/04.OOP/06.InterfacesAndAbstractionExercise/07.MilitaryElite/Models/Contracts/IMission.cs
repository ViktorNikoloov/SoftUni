using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }

        public State State { get; }

        public void CompleteMission();
    }
}