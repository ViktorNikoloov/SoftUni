using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
