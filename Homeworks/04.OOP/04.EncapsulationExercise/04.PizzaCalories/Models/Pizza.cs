using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const string Name_Arg_Exs_Msg = "Pizza name should be between 1 and 15 symbols.";
        private const string Topping_Count_Arg_Exs_Msg = "Number of toppings should be in range [0..10].";

        private const int Min_Name_Length = 1;
        private const int Max_Name_Length = 15;
        private const int Max_Toppings_Count = 15;


        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        private Pizza()
        {
            toppings = new List<Topping>();

        }
        public Pizza(string name)
            :this()
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || (value.Length < Min_Name_Length || value.Length > Max_Name_Length))
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
            if (ToppingsCount >= Max_Toppings_Count)
            {
                throw new ArgumentException(Topping_Count_Arg_Exs_Msg);
            }

            toppings.Add(topping);
        }





    }
}
