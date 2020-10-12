using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string weight;
        public Car()
        {
            Weight = "n/a";
            Color = "n/a";
        }
        public Car(string model, Engine engine) : this()
        {
            Model = model;
            Engine = engine;
        }

        //public Car(string model, Engine engine, string weight) : this(model, engine)
        //{
        //    Weight = weight;
        //}

        //public Car(Engine engine, string model, string color) : this(model, engine)
        //{
        //    Color = color;
        //}

        //public Car(string model, Engine engine, string weight, string color) : this(model, engine, weight) 
        //{
        //    Color = color;
        //}

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight { get; set; } //optional

        public string Color { get; set; } //optional

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"{Engine.Model}:");
            sb.AppendLine($"Power: {Engine.Power}");
            sb.AppendLine($"Displacement: {Engine.Displacement}");
            sb.AppendLine($"Efficiency: {Engine.Efficiency}");
            sb.AppendLine($"Weight: {Weight}");
            sb.AppendLine($"Color: {Color}");

            return sb.ToString().Trim();

        }

    }
}
