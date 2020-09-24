
using System;

namespace ExamSubmissions
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред, получавате брой студенти: цяло число [1-1000].
            //•	На втори ред получавате брой задачи: цяло число[1 - 10000].
            int student = int.Parse(Console.ReadLine());
            int tasks = int.Parse(Console.ReadLine());

            //calculation
            //Всеки студент изпраща средно по 2.8 решения на всяка задача. 
            //Всички събмишъни на студент закръглете към по - горното цяло число. 
            //На всяка трета задача, студентите изпращат по още едно решение допълнително.
            //5 KB могат да съхранят до 10 решения. 
            double currSubmissions = student * Math.Ceiling(tasks * 2.8);
            double extraTask = student * Math.Floor(tasks / 3.0);
            double totalSub = currSubmissions + extraTask;

            //output
            Console.WriteLine($"{5 * Math.Ceiling(totalSub / 10.0)} KB needed");
            Console.WriteLine($"{totalSub} submissions");

        }
    }
}
