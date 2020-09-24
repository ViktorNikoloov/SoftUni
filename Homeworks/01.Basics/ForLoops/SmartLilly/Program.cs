using System;

namespace SmartLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int age = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            
            double money = 0;
            double toys = 0;
            double savings = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    
                    money += 10;
                    savings += money;
                    savings -= +1; //brother effect
                }
                else
                {
                    toys += 1;
                }

            }
            double savedMoney = (toys * toysPrice) + savings;

            if (savedMoney >= machinePrice)
            {
            Console.WriteLine($"Yes! {savedMoney - machinePrice:f2}");
            }
            else
            {
            Console.WriteLine($"No! {machinePrice - savedMoney:f2}");
            }


        }
    }
}
