using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Id { get; private set; }
    }
}
