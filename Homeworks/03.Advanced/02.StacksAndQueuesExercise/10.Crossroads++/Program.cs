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
            bool isSafety = false;
            string currCar = string.Empty;

            while (command != "END")
            {
                cars.Enqueue(command);

                if (command == "green")
                {
                    Queue<char> crossingCar = new Queue<char>(cars.Dequeue());
                    currCar = crossingCar.ToString();

                    for (int i = 0; i < greenLight; i++)
                    {
                        if (crossingCar.Count == 0)
                        {
                            crossingCar = new Queue<char>(cars.Dequeue());
                            currCar = crossingCar.ToString();

                        }
                        crossingCar.Dequeue();
                    }

                    for (int i = 0; i < freeWindow; i++)
                    {
                        if (crossingCar.Count == 0)
                        {
                            break;
                        }

                        crossingCar.Dequeue();
                        
                    }

                    if (crossingCar.Count == 0)
                    {
                        isSafety = true;
                    }

                }


                command = Console.ReadLine();
            }
        }
    }
}
