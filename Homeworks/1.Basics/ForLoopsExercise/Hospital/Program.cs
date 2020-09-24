using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            // На първия ред – периода, за който трябва да направите изчисления. Цяло число в интервала [1 ... 1000]
            // На следващите редове(равни на броят на дните) – броя пациенти, които пристигат за преглед за текущия ден. Цяло число в интервала[0…10 000]

            int days = int.Parse(Console.ReadLine());

            int doctors = 7;
            int treated = 0;
            int untreated = 0;

            for (int i = 1; i <= days; i++)
            {
                int patients = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    if (untreated > treated)
                    {
                        doctors += 1;
                    }
                    
                }
                if (patients > doctors)
                {
                    untreated += patients - doctors;
                }
                if (patients < doctors)
                {
                    treated += patients;
                }
                else if (patients <= 0)
                {
                    treated += 0;
                }
                else
                {
                    treated += doctors;
                }
            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }

    }
}
