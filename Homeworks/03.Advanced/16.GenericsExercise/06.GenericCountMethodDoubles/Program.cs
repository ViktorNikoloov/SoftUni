using System;

namespace _06.GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.List.Add(input);
            }

            double elementToCompared = double.Parse(Console.ReadLine());

            int result = box.GetCompared(elementToCompared);

            Console.WriteLine(result);
        }
    }
}
