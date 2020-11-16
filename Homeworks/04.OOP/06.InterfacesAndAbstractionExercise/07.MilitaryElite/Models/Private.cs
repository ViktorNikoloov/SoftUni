using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, int id, decimal salary) 
            :base(firstName, lastName, id)
        {
            Salary = salary;
          
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        => $"{base.ToString()} Salary: {Salary:F2}";
    }
}
