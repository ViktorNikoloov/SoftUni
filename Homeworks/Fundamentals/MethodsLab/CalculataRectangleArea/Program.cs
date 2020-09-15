using System;

namespace CalculataRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int area = RectangleArea(widht, height);

            Console.WriteLine(area);
        }

        static int RectangleArea(int widht, int height)
        {
            return widht * height;
        }
    }
}
