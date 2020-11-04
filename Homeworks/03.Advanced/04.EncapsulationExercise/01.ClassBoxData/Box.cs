using System;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private const string EXS_STRING_NAME = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                IsItValid(value, nameof(Length));

                length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                IsItValid(value, nameof(Width));

                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                IsItValid(value, nameof(Height));

                height = value;
            }
        }

        public double LateralSurfaceArea() //2lh + 2wh
        => (2 * Length * Height) + (2 * Width * Height);


        public double SurfaceArea() //2lw + 2lh + 2wh
        => LateralSurfaceArea() + (2 * Length * Width);

        public double Volume() //lwh
            => Length * Width * Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
            .AppendLine($"Surface Area - {SurfaceArea():f2}")
            .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
            .AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().TrimEnd();
        }


        private void IsItValid(double side, string name)
        {
            if (side <= 0)
            {
                throw new ArgumentException(string.Format(EXS_STRING_NAME, name));
            }
        }
    }
}
