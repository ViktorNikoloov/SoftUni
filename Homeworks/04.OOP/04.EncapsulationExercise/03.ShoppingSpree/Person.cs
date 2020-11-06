using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree.Common
{
    public class Person
    {
        private const string CANNOT_AFFORD_MSG = "{0} can't afford {1}";
        private const string CAN_AFFORD_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly List<Product> bag;

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
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.MONEY_EXS_MSG);
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
                => bag.AsReadOnly();
        }

        public string AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return string.Format(CANNOT_AFFORD_MSG, Name, product.Name);
            }

            Money -= product.Cost;
            bag.Add(product);

            return string.Format(CAN_AFFORD_MSG, this.Name, product.Name);
        }

        public override string ToString()
        {
            string stringoutput = Bag.Count == 0 ? "Nothing bought" : string.Join(", ", Bag);

            return ($"{Name} - {stringoutput}");
        }
    }
}
