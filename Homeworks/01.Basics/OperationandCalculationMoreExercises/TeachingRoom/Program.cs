using System;

namespace TeachingRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            //Condition
            //input
            double length = double.Parse(Console.ReadLine()) * 100; //m->sm
            double wedth = double.Parse(Console.ReadLine()) * 100;

            //calculation
            // 
            double withoutCoridor = wedth - 100;
            double desk = Math.Floor(withoutCoridor / 70);
            double rows = Math.Floor(length / 120);
            //output

            double places = desk * rows - 3;
            Console.WriteLine(places);
        }
    }
}
