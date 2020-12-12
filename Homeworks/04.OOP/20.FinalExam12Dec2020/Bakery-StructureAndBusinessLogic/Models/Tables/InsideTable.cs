namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal DefaultInsideTablePricePerPerson = 2.50M;

        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, DefaultInsideTablePricePerPerson)
        {
        }
    }
}
