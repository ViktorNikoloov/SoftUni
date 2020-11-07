using System;
using System.Globalization;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)

        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                string pizzaName = string.Empty;
                if (pizzaInfo.Length <= 1)
                {
                    pizzaName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pizzaInfo[0].ToLower());
                }
                else
                {
                    pizzaName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pizzaInfo[1].ToLower());
                }

                Pizza pizza = new Pizza(pizzaName);

                string[] doughtInfo = Console.ReadLine().Split();
                string doughType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(doughtInfo[1].ToLower());
                string doughTechnique = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(doughtInfo[2].ToLower());
                double doughWeight = double.Parse(doughtInfo[3]);

                Dough dough = new Dough(doughType, doughTechnique, doughWeight);
                pizza.Dough = dough;

                string[] toppingInfo = Console.ReadLine().Split();
                while (toppingInfo[0] != "END")
                {
                    string toppingType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(toppingInfo[1].ToLower());
                    double toppingWeight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    toppingInfo = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

