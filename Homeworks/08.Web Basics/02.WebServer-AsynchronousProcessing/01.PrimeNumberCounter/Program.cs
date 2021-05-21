using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01.PrimeNumberCounter
{
    class Program
    {
        static int Count = 0;
        static object lockObj = new object();

        static void Main(string[] args)
        {
            /* 
             * 01.Synchronous code's Count and Time // PrintPrimeCount
             *-664580
             *-00:00:13.8449974
             * 
             * 02.If we use 4 Theads for the operation
             *-663748 // There is no precision calculation !!!
             *-00:00:07.6976238 // The time is better but... ^
             *
             *03. !! We use 4 Threads again but this time we are lock the common variable !!
             *00:00:08.2430543
             *664580 // And the result is correct !
             */

            //ThreadTest(10_000);

            //TaskTest(10000);

            //ThreadTesting();

            Stopwatch sw = Stopwatch.StartNew();

            HttpClient httpClient = new HttpClient();
            List<Thread> threads = new List<Thread>();
            List<Task> tasks = new List<Task>();

            for (int i = 0; i <= 100; i++)
            {
                // ThreatTime: 00:00:02.1976358
                var thread = new Thread(() =>
               {
                   var url = $"https://vicove.com/vic-{i}";
                   var httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult();
                   var vic = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                   //Console.WriteLine(vic.Length);
               });
                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine($"Tread Time: {sw.Elapsed}");

            // TaskTime: 00:00:00.0401025 - No async and await
            // TaskTime: 00:00:00.0026317 - With async and await
            for (int i = 0; i <= 100; i++)
            {
                var task = Task.Run(async () =>
                {
                    HttpClient httpClient = new HttpClient();
                    var url = $"https://vicove.com/vic-{i}";
                    var httpResponse = await httpClient.GetAsync(url);
                    var vic = await httpResponse.Content.ReadAsStringAsync();
                   // Console.WriteLine(vic.Length);
                });
                tasks.Add(task);

            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Task Time: {sw.Elapsed}");
            Console.ReadLine();

           

        }


        static void PrintPrimeCount(int min, int max)
        {

            for (int i = min; i <= max; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    /* monitor */
                    //Monitor.Enter(lockObj);
                    //Count++;
                    //Monitor.Exit(lockObj);

                    lock (lockObj)
                    {
                        Count++;
                    }
                }
            }


        }

        static void ThreadTesting()
        {
            Stopwatch sw = Stopwatch.StartNew();

            //Thread thred1 = new Thread(() =>
            //{
            //    //code
            //});

            Thread thread = new Thread(() => PrintPrimeCount(1, 2_500_000));
            thread.Start();
            thread.Name = "First";

            Thread thread2 = new Thread(() => PrintPrimeCount(2_500_001, 5_000_000));
            thread2.Start();
            thread2.Name = "Second";

            Thread thread3 = new Thread(() => PrintPrimeCount(5_000_001, 7_500_000));
            thread3.Start();
            thread3.Name = "Third";

            Thread thread4 = new Thread(() => PrintPrimeCount(7_500_001, 10_000_000));
            thread4.Start();
            thread4.Name = "Fourth";

            thread.Join(); // Waiting for thread to finished
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(Count);

            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        static void ThreadCreatTimeTest(int threadCount)
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < threadCount; i++)
            {
                Thread innerThread = new Thread(() =>
                {
                    while (true)
                    {

                    }
                });
                innerThread.Start();
                threads.Add(innerThread);

                Console.WriteLine(sw.Elapsed);
            }
        }

        static void TaskCreatTimeTest(int taskCount)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < taskCount; i++)
            {
                Task.Run(() =>
                {
                    while (true)
                    {

                    }
                });

                Console.WriteLine(sw.Elapsed);
                Console.ReadLine();
            };
        }

    }
}
