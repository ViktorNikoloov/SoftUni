using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(firstName, lastName, id)
        {
            CodeNumber = CodeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        => $"Name: {FirstName} {LastName} Id: {Id} Code Number: {CodeNumber}";
    }
}
