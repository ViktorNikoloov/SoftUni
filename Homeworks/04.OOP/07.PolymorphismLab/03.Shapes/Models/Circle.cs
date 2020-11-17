using System;

using Shapes.Models.Contracts;

namespace Shapes.Models
{
    public class Circle : Shape, ICircle
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
