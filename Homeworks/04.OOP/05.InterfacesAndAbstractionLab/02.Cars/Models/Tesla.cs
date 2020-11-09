using Cars.Contracts;

namespace Cars.Models
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Battery { get; set; }

        public string Start()
        => ("Engine start");

        public string Stop()
        => ("Breaaak!");

        public override string ToString()
        {

            return $"{Color} Tesla {Model} with {Battery} Batteries\n{Start()}\n{Stop()}";
        }
    }
}
