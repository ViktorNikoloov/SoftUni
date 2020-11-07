using System;
using System.Collections.Generic;

using _04.PizzaCalories;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const string Name_Arg_Exs_Msg = "Pizza name should be between 1 and 15 symbols.";
        private const string Topping_Count_Arg_Exs_Msg = "Number of toppings should be in range [0..10].";


        private string name;
        private string dough;
        private readonly List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;

            toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 15))
                {
                    throw new ArgumentException(Name_Arg_Exs_Msg);
                }

                name = value;
            }

        }

        public Dough Dough { get; set; }

        public IReadOnlyCollection<Topping> Toppings
        {
            get
            {
                return toppings.AsReadOnly();
            }
            
        }

        public int ToppingsCount
            => toppings.Count;

        public string TotalCalories
        {
            get
            {
                double doughCalories = double.Parse(Dough.Calories());
                double toppingsCalories = 0;

                foreach (var topping in toppings)
                {
                    toppingsCalories += double.Parse(topping.Calories());
                }
                double result = doughCalories + toppingsCalories;

                return $"{result:F2}";
            }
        }

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount >= 10)
            {
                throw new ArgumentException(Topping_Count_Arg_Exs_Msg);
            }

            toppings.Add(topping);
        }





    }
}
