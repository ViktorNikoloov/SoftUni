using Shapes.Models.Contracts;

namespace Shapes.Models
{
    public class Rectangle : Shape, IRectangle
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return (2 * Height) + (2 * Width);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}

