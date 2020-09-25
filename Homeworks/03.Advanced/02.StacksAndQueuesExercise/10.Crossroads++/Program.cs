using System;
using System.Collections.Generic;
using System.Data;

namespace _10.Crossroads__
{
    class Program
    {
        static void Main(string[] args)
        {

            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            Queue<char> crossingCar = new Queue<char>();

            bool isSafety = true;
            string currCar = string.Empty;
            int carsPassed = 0;

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else if (command == "green" && cars.Count != 0)
                {
                    currCar = cars.Dequeue();
                    crossingCar = new Queue<char>(currCar);

                    for (int i = 0; i < greenLight; i++)
                    {
                        if (crossingCar.Count == 0)
                        {
                            if (cars.Count == 0)
                            {
                                carsPassed++;
                                break;
                            }
                            else
                            {
                                currCar = cars.Dequeue();
                                crossingCar = new Queue<char>(currCar);
                            }
                            carsPassed++;

                        }
                        crossingCar.Dequeue();

                        if (i == greenLight - 1)
                        {
                            for (int j = 0; j < freeWindow; j++)
                            {
                                if (crossingCar.Count == 0)
                                {
                                    break;
                                }
                                crossingCar.Dequeue();

                            }
                            if (crossingCar.Count != 0)
                            {
                                isSafety = false;
                                break;
                            }
                            else
                            {
                                carsPassed++;
                            }
                        }

                    }
                    if (!isSafety)
                    {
                        break;

                    }

                }

                command = Console.ReadLine();
            }


            if (crossingCar.Count != 0)
            {
                isSafety = false;
            }

            if (isSafety)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currCar} was hit at {crossingCar.Dequeue()}.");
            }
        }
    }
}