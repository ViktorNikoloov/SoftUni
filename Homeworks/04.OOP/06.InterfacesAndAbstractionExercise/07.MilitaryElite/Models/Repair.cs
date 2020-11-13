using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }
    }
}
