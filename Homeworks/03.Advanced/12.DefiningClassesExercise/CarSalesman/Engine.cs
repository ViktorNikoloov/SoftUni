using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        
        public Engine()
        {
            Displacement = "n/a";
            Efficiency = "n/a";
        }
        public Engine(string model, int power) :this()
        {
            Model = model;
            Power = power;
        }
        //public Engine(string model, int power, int displacement)
        //     : this(model, power)
        //{
        //    Displacement = displacement;
        //}

        //public Engine(string model, int power, int displacement, string efficiency)
        //    : this(model, power, displacement)
        //{
        //    Efficiency = efficiency;
        //}

        public string Model { get; set; }

        public int Power { get; set; }

        public string Displacement { get; set; } //optional

        public string Efficiency { get; set; } //optional


    }
}
