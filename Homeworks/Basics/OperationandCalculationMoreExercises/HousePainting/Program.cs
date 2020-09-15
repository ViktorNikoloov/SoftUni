using System;

namespace HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Condition
            //Напишете програма, която да пресмята колко литра боя е нужна за боядисването на къщa.
            //Като за стените се използва зелена боя, а за покрива – червена. 
            //Разхода на зелената боя е 1 литър за 3.4 м2, а на червената – 1 литър за 4.3 м2.

            // input
            // 1.x – височината на къщата – реално число в интервала [2...100]
            // 2.y – дължината на страничната стена – реално число в интервала[2...100]
            // 3.h – височината на триъгълната стена на прокрива – реално число в интервала[2...100]
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            //calculation Walls - green paint - 1 литър за 3.4 м2
            //•	Предната и задната стена са квадрати със страна „x“
            //o на предната стена има правоъгълна врата с широчина 1.2м и височина 2м
            //•	Страничните стени са правоъгълници със страни „x“ и „y“
            //o и на двете странични стени има по един квадратен прозорец със страна 1.5м
            double frontAndBackWalls = (x * x) + (x * x) - (1.2 * 2);
            double sideWalls = ((x * y) - (1.5 * 1.5)) + ((x * y) - (1.5 * 1.5));
            double greenPaintLiiter = (frontAndBackWalls + sideWalls) / 3.4;

            //calculation roof - red paint - 1 литър за 4.3 м2.
            //  Покривът има следните размери:
            //•	Два правоъгълника със страни „x“ и „y“
            //•	Два равностранни триъгълника със страна „x“ и височина „h“
            //Трябва да пресметнете площта на всички страни и площта на покрива, за да
            //намерите колко литра от всяка боя ще са нужни.
            double roofRectangle = (x * y) + (x * y);
            double roofTriangle = (x * h / 2) + (x * h / 2);
            double redPaintLiters = (roofRectangle + roofTriangle) / 4.3;




            //output
            //•	Литрите зелена боя
            //•	Литритe червена боя
            //Форматирани до вторият знак след десетичната запетая.
            Console.WriteLine($"{greenPaintLiiter:F2}");
            Console.WriteLine($"{redPaintLiters:F2}");

        }
    }
}
