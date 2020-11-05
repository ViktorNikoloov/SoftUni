using System;
using System.Collections.Generic;

using _03.ShoppingSpree.Common;


namespace _03.ShoppingSpree
{
    public class Person
    {
        private const string CANNOT_AFFORD_MSG = "{0} can't afford {1}";
        private const string CAN_AFFORD_MSG = "{} bought {}";

        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            bag = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            Name = name;
            Money = money;
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

        public decimal Money
        {
            get
            {
                return money;

            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.MONEY_EXS_MSG);
                }

                money = value;
            }
        }

        public List<Product> Bag
        {
            get
            {
                return bag;
            }
            set
            {
                bag = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                throw new ArgumentException(string.Format(CANNOT_AFFORD_MSG, Name, product.Name));
            }

            Money -= product.Cost;
            bag.Add(product);

            return string.Format(CAN_AFFORD_MSG, Name, product.Name);
        }

    }
}
