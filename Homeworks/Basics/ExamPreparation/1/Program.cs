using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	Първи ред – дохода на Деси за месец – реално число в интервала [1500.00… 10 000.00]
            //•	Втори ред – броят месеци, с които Деси разполага, за да спести парите – цяло число в интервала
            //[3... 12]
            //•	Трети ред – сумата, от която Деси има нужда, за да покрие личните си разходи – реално число
            //в интервала[300.00... 1000.00]
            double budget = double.Parse(Console.ReadLine());
            int mounts = int.Parse(Console.ReadLine());
            double neededMoney = double.Parse(Console.ReadLine());

            //calculation
            double unknowExpense = budget * 0.3;
            double leftMoney = budget - unknowExpense - neededMoney;
            double totalSum = leftMoney * mounts;

            //output
            Console.WriteLine($"She can save {leftMoney / budget * 100:f2}%");
            Console.WriteLine($"{totalSum:f2}");


        }
    }
}
