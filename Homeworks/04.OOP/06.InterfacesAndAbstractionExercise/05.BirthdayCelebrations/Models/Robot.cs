using _05.BirthdayCelebrations.Models.Contracts;

namespace _05.BirthdayCelebrations
{
    public class Robot : IRobot
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
