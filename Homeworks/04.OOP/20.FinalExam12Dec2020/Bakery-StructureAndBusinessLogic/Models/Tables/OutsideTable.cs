namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal DefaultOutsideTablePricePerPerson = 3.50M;

        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, DefaultOutsideTablePricePerPerson)
        {

        }
    }
}
