using System;

using _03.ShoppingSpree.Common;


namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
        

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.NAME_EXS_MSG);
                }

                name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.MONEY_EXS_MSG);
                }

                cost = value;
            }
        }
    }
}
