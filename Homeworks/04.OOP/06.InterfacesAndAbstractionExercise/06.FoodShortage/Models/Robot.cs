using _06.FoodShortage.Models.Contracts;

namespace _06.FoodShortage
{
    public class Robot : IRobot, IIdentifiable
    {
        private string id;
        private string model;

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Id
        {
            get => id;
            private set
            {
                id = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                model = value;
            }
        }
    }
}
