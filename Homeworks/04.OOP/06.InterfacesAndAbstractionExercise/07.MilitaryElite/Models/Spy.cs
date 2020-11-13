using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id, int codeNumber)
            : base(firstName, lastName, id)
        {
            CodeNumber = CodeNumber;
        }

        public int CodeNumber { get; private set; }
    }
}
