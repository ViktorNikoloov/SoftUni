using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            :base(firstName, lastName, id)
        {
            Salary = salary;
          
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        => $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
    }
}
