using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const string Name_Arg_Exs_Msg = "Pizza name should be between 1 and 15 symbols.";
        private const string Topping_Count_Arg_Exs_Msg = "Number of toppings should be in range [0..10].";


        private string name;
        private Dough dough;
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
                if (string.IsNullOrEmpty(value) || (value.Length < 1 || value.Length > 15))
                {
                    throw new ArgumentException(Name_Arg_Exs_Msg);
                }

                name = value;
            }

        }

        public Dough Dough
        {
            get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }

        public IReadOnlyCollection<Topping> Toppings
        {
            get
            {
                return toppings.AsReadOnly();
            }

        }

        public int ToppingsCount
            => toppings.Count;

        public double TotalCalories
        {
            get
            {
                double doughCalories = Dough.CaloriesPerGram;
                double toppingsCalories = 0;

                foreach (var topping in toppings)
                {
                    toppingsCalories += topping.CaloriesPerGram;
                }

                return doughCalories + toppingsCalories;
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
