namespace Shapes.Models.Contracts
{
    public interface IShape
    {
        public double CalculatePerimeter();

        public double CalculateArea();

        public string Draw();
    }
}
