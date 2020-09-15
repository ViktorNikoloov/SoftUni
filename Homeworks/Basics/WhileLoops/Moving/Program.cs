using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Широчина на свободното пространство - цяло число в интервала[1...1000]
            int wide = int.Parse(Console.ReadLine());
            //2.Дължина на свободното пространство - цяло число в интервала[1...1000]
            int length = int.Parse(Console.ReadLine());
            //3.Височина на свободното пространство - цяло число в интервала[1...1000]
            int hight = int.Parse(Console.ReadLine());

            int space = wide * length * hight;
            double spaceLeft = 0;
            string box = Console.ReadLine();

            //4.На следващите редове(до получаване на команда "Done") -брой кашони, които се пренасят в квартирата - цели числа в интервала[1...10000];
            while (box != "Done" && spaceLeft < space)
            {
                int boxes = int.Parse(box);
                spaceLeft += boxes;

                if (spaceLeft > space)
                {
                    Console.WriteLine($"No more free space! You need {spaceLeft - space} Cubic meters more.");
                    break;
                }

                box = Console.ReadLine();

            }

            if (spaceLeft < space)
            {
                Console.WriteLine($"{space - spaceLeft} Cubic meters left.");
            }

        }
    }
}
