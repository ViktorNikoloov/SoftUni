using System;
using System.Collections.Generic;

namespace _04.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("_");

                string typeList = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song();

                song.TypeList = typeList;
                song.Name = name;
                song.Time = time;

                songs.Add(song);

            }

            string option = Console.ReadLine();
            if (option == "all")
            {
                foreach (var item in songs)
                {

                    Console.WriteLine(item.Name);
                }
                
            }
            else
            {
                foreach (var item in songs)
                {
                    if (item.TypeList == option)
                    {
                        Console.WriteLine(item.Name);
                    }

                }
            }
        }
    }

    class Song
    {
        //Type List, Name and Time.
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }


        
    }
}
