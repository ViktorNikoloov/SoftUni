using System;

namespace _7._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред до получаване на командата "Finish" - име на филма – текст
            //•	На втори ред – свободните места в салона за всяка прожекция – цяло число[1 … 100]
            //•	За всеки филм, се чете по един ред до изчерпване на свободните места в залата или до получаване на командата "End":
            //o Типа на закупения билет - текст("student", "standard", "kid")
            string MovieName = Console.ReadLine();
            int counter = 0;
            int student = 0;
            int standard = 0;
            int kid = 0;

            while (MovieName != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                int leftSeats = freeSeats;
                string command = Console.ReadLine();

                while (command != "End")
                {
                    leftSeats--;
                    counter++;
                    if (command == "student")
                    {
                        student++;
                    }
                    if (command == "standard")
                    {
                        standard++;
                    }
                    if (command == "kid")
                    {
                        kid++;
                    }
                    if (leftSeats <= 0)
                    {
                        break;
                    }
                    command = Console.ReadLine();

                }
                Console.WriteLine($"{MovieName} - {(double)counter / freeSeats * 100:f2}% full.");
                counter = 0;
                MovieName = Console.ReadLine();
            }
            int totalTickets = student + standard + kid;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(double)student / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)standard / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)kid / totalTickets * 100:f2}% kids tickets.");

        }
    }
}
