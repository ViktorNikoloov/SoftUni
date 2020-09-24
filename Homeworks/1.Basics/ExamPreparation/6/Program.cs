using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред – брой участници в състезанието – цяло положително число в интервала [1…10]
            //За всеки един от участниците се четат следните редове до прочитане на командата "Stop baking!":
            //•	Първи ред – име на участник - текст
            //•	Втори ред – вид сладкиш -текст с възможности: "cookies", "cakes", "waffles"
            //•	Трети ред – брой изпечени сладкиши от дадения вид -цяло число в интервала[1…1000]
            int people = int.Parse(Console.ReadLine());
            double totalSum = 0;
            int totalNum = 0;

            for (int i = 0; i < people; i++)
            {
                int currCookies = 0;
                int currCakes = 0;
                int currWaffles = 0;
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                while (type != "Stop baking!")
                {
                    
                    int number = int.Parse(Console.ReadLine());
                    totalNum += number;

                    switch (type)
                    {
                        //сладки - 1,50, торти - 7,80, гофрети - 2,30
                        case "cookies":
                            totalSum += number * 1.50;
                            currCookies += number;
                            break;

                        case "cakes":
                            totalSum += number * 7.80;
                            currCakes += number;
                            break;

                        case "waffles":
                            totalSum += number * 2.30;
                            currWaffles += number;
                            break;

                    }
                    type = Console.ReadLine();

                }

                Console.WriteLine($"{name} baked {currCookies} cookies, {currCakes} cakes and {currWaffles} waffles.");
                

            }

            Console.WriteLine($"All bakery sold: {totalNum}");
            Console.WriteLine($"Total sum for charity: {totalSum:f2} lv.");
        }
    }
}
