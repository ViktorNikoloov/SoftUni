using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestKeg = double.MinValue;
            string kegName = "";

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double currVolume = Math.PI * (radius * radius) * height;

                if (currVolume > biggestKeg)
                {
                    biggestKeg = currVolume;
                    kegName = name;
                }
            }
            Console.WriteLine(kegName);
        }
    }
}
