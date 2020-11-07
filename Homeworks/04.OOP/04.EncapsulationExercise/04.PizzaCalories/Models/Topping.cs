using System;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const string Topping_Arg_Exs_Msg = "Cannot place {0} on top of your pizza.";
        private const string Weight_Arg_Exs_Msg = "{0} weight should be in the range [1..50].";

        private const double BaseToppingCalories = 2.0;
        private const double MeatToppingCalories = 1.2;
        private const double VeggiesToppingCalories = 0.8;
        private const double CheeseToppingCalories = 1.1;
        private const double SauceToppingCalories = 0.9;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
                {
                    throw new ArgumentException(string.Format(Topping_Arg_Exs_Msg, value));
                }

                type = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (1 > value || value > 50)
                {
                    throw new ArgumentException(string.Format(Weight_Arg_Exs_Msg, this.Type));
                }

                weight = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                double toppingType = 0;
                switch (this.Type)
                {
                    case "Meat":
                        toppingType = MeatToppingCalories;
                        break;

                    case "Veggies":
                        toppingType = VeggiesToppingCalories;
                        break;

                    case "Cheese":
                        toppingType = CheeseToppingCalories;
                        break;

                    default:
                        toppingType = SauceToppingCalories;
                        break;
                }

                return (BaseToppingCalories * this.Weight) * toppingType;
            }
        }

    }
}
