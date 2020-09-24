using System;

namespace _3._Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	Първи ред – държава – текст ("Russia", "Bulgaria" или "Italy")
            //•	Втори ред – уред - текст("ribbon", "hoop" или "rope")
            string country = Console.ReadLine();
            string type = Console.ReadLine();
            double firstScore = 0;
            double secondScore = 0;

            switch (country)
            {
                case "Russia":
                    switch (type)
                    {
                        case "ribbon":
                            firstScore += 9.100;
                            secondScore += 9.400;
                            break;
                        case "hoop":
                            firstScore += 9.300;
                            secondScore += 9.800;
                            break;
                        case "rope":
                            firstScore += 9.600;
                            secondScore += 9.000;
                            break;
                    }
                    break;
                case "Bulgaria":
                    switch (type)
                    {
                        case "ribbon":
                            firstScore += 9.600;
                            secondScore += 9.400;
                            break;
                        case "hoop":
                            firstScore += 9.550;
                            secondScore += 9.750;
                            break;
                        case "rope":
                            firstScore += 9.500;
                            secondScore += 9.400;
                            break;
                    }
                    break;
                case "Italy":
                    switch (type)
                    {
                        case "ribbon":
                            firstScore += 9.200;
                            secondScore += 9.500;
                            break;
                        case "hoop":
                            firstScore += 9.450;
                            secondScore += 9.350;
                            break;
                        case "rope":
                            firstScore += 9.700;
                            secondScore += 9.150;
                            break;
                    }
                    break;
            }
            double totalScore = firstScore + secondScore;
            //максималната оценка - 20.
            double leftScore = 20 - totalScore;
            Console.WriteLine($"The team of {country} get {totalScore:f3} on {type}.");
            Console.WriteLine($"{(leftScore / 20.0) * 100:f2}% ");
        }
    }
}
