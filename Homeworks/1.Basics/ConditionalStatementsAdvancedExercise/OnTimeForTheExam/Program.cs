using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Първият ред съдържа час на изпита – цяло число от 0 до 23.
            //Вторият ред съдържа минута на изпита – цяло число от 0 до 59.
            //Третият ред съдържа час на пристигане – цяло число от 0 до 23.
            //Четвъртият ред съдържа минута на пристигане – цяло число от 0 до 59.

            int examHour = int.Parse(Console.ReadLine()) * 60;
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine()) * 60;
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examTime = examHour + examMinutes;
            int arrivamTime = arrivalHour + arrivalMinutes;



            //Счита се, че студентът е дошъл навреме, ако е пристигнал в часа на изпита или до половин час преди това. 
            if (arrivamTime == examTime)
            {
                Console.WriteLine("On time");
                
            }
            else if (arrivamTime <= examTime && arrivamTime >= examTime - 30)
            {
                int onTime = (examTime - arrivamTime) % 60;

                if (onTime < 10)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{onTime} minutes before the start");
                }
                else
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{onTime} minutes before the start");
                }

            }
            //Ако е пристигнал по-рано повече от 30 минути, той е подранил.
            //за подраняване с 1 час или повече. Минутите винаги печатайте с 2 цифри, например “1:05”.
            if (arrivamTime <= examTime - 31 && arrivamTime >= examTime - 60 || arrivamTime < examTime - 60)
            {
                int earlyMinutes = (examTime - arrivamTime) % 60;
                double earlyHours = (examTime - arrivamTime) / 60;

                if (earlyHours == 0)
                {

                    Console.WriteLine("Early");
                    Console.WriteLine($"{earlyMinutes:d2} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{Math.Floor(earlyHours)}:{earlyMinutes:d2} hours before the start");
                }
            }
            //Ако е дошъл след часа на изпита, той е закъснял.
            //За закъснение от 1 час или повече. Минутите винаги печатайте с 2 цифри, например “1:03”.
            //&& arrivamTime >= examTime - 60 || arrivamTime < examTime - 60
            if (arrivamTime > examTime)
            {
                int lateMinutes = (arrivamTime - examTime) % 60;
                double lateHours = (arrivamTime - examTime) / 60;

                if (lateHours == 0)
                {

                    Console.WriteLine("Late");
                    Console.WriteLine($"{lateMinutes} minutes after the start");
                }
                else
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{Math.Floor(lateHours)}:{lateMinutes:d2} hours after the start");
                }
            }
        }
    }
}
