using _04.BorderControl.Models.Contracts;

namespace _04.BorderControl.Models
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
            set
            {
                id = value;
            }
        }

        public string Model
        {
            get => model;
            set
            {
                model = value;
            }
        }
    }
}
