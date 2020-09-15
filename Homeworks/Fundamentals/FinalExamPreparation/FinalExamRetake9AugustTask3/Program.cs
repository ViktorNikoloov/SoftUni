using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamRetake9AugustTask3
{
    class Record
    {
        public int Like { get; set; }
        public int Comment { get; set; }

        public Record()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Record> info = new Dictionary<string, Record>();

            string[] command = Console.ReadLine().Split(": ",StringSplitOptions.RemoveEmptyEntries);
            while (!command.Contains("Log out"))
            {
                string username = command[1];
                Record record = new Record();

                if (command.Contains("New follower"))
                {
                    if (!info.ContainsKey(username))
                    {
                        info.Add(username, record);
                    }
                }
                else if (command.Contains("Like")) //{username}: {count}"
                {
                    int count = int.Parse(command[2]);
                    
                    if (!info.ContainsKey(username))
                    {
                        record.Like = count;
                        info.Add(username, record);
                    }
                    else
                    {
                        info[username].Like += count;
                    }
                }
                else if (command.Contains("Comment"))
                {
                    if (!info.ContainsKey(username))
                    {
                        record.Comment = 1;
                        info.Add(username, record);
                    }
                    else
                    {
                        info[username].Comment += 1;
                    }
                }
                else if (command.Contains("Blocked"))
                {
                    if (info.ContainsKey(username))
                    {
                        info.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }

                command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }
            
            Console.WriteLine($"{info.Keys.Count} followers");
            foreach (var item in info.OrderByDescending(x => x.Value.Like).ThenBy(x => x.Key))
            {
               
                Console.WriteLine($"{item.Key}: {(item.Value.Like + item.Value.Comment)}");
            }
        }
    }
}
