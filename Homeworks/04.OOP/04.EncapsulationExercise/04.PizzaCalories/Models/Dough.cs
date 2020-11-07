using System;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const string Dought_Arg_Exs_Msg = "Invalid type of dough.";
        private const string Weight_Arg_Exs_Msg = "Dough weight should be in the range [1..200].";

        private const double BaseDoughtCalories = 2.0;
        private const double WhiteDoughCalories = 1.5;
        private const double WholegrainDoughCalories = 1.0;

        private const double CrispyDoughCalories = 0.9;
        private const double ChewyDoughCalories = 1.1;
        private const double HomemadeDoughCalories = 1.0;

        private string type;
        private string bakingTechnique;
        private double weight;

        public Dough(string type, string bakingTechnique, double weight)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
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
                if (value != "White" && value != "Wholegrain")
                {
                    throw new ArgumentException(Dought_Arg_Exs_Msg);
                }

                type = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (value != "Crispy" && value != "Chewy" && value != "Homemade")
                {
                    throw new ArgumentException(Dought_Arg_Exs_Msg);
                }

                bakingTechnique = value;
            }

        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (1 > value || value > 200)
                {
                    throw new ArgumentException(Weight_Arg_Exs_Msg);
                }

                weight = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                double doughtCalories = 0;
                double techniqueCalories = 0;

                switch (this.Type)
                {
                    case "White":
                        doughtCalories = WhiteDoughCalories;
                        break;

                    default:
                        doughtCalories = WholegrainDoughCalories;
                        break;
                }

                switch (this.BakingTechnique)
                {
                    case "Crispy":
                        techniqueCalories = CrispyDoughCalories;
                        break;

                    case "Chewy":
                        techniqueCalories = ChewyDoughCalories;
                        break;

                    default:
                        techniqueCalories = HomemadeDoughCalories;
                        break;

                }

                return (BaseDoughtCalories * this.Weight) * doughtCalories * techniqueCalories;
            }
        }

    }
}
