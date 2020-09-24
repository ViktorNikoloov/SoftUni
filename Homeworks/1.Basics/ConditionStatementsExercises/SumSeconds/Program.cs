using System;

namespace SumSecondsModulo
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            int swimmerOneTime = int.Parse(Console.ReadLine());
            int swimmerTwoTime = int.Parse(Console.ReadLine());
            int swimmerThreeTime = int.Parse(Console.ReadLine());

            int totalTime = swimmerOneTime + swimmerThreeTime + swimmerTwoTime;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:" +
                    $"{seconds}");
            }
        }
    }
}
