using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(input);

            
            while (songs.Count != 0)
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string[] song = command.Split("Add ", StringSplitOptions.RemoveEmptyEntries);

                    if (!songs.Contains(song[0]))
                    {
                        songs.Enqueue(song[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{song[0]} is already contained!");
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
