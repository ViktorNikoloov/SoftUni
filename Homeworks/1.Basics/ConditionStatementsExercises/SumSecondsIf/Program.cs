using System;

namespace SumSecondsIf
{
    class Program
    {
        static void Main(string[] args)
        
        {  
            int totalSeconds = 0;

            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds += int.Parse(Console.ReadLine());

            int minutes = 0;
            int seconds = 0;

            if (totalSeconds >= 120)
            {
                minutes += 2;
                seconds = totalSeconds - 120;
            }
              else  if (totalSeconds >= 60)
                {
                    minutes += 1;
                    seconds = totalSeconds - 60;
                }

                else
                {
                    minutes += 0;
                    seconds = totalSeconds;
                }

                Console.WriteLine($"{minutes}:{seconds:d2}");
            
        }
    }
}
