using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            IDrawable circle = new Circle(radius);
            IDrawable rectangle = new Rectangle(width, height);

            circle.Draw();
            rectangle.Draw();

        }
    }
}
