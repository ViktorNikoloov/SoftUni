using System.Collections.Generic;
using System.Linq;

using _06.FoodShortage.Core;
using _06.FoodShortage.IO.Contracts;
using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Contracts;


namespace _06.FoodShortage
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        ICitizen citizen = new Citizen();
        ICitizen rebel = new Rebel();
        private readonly ICollection<ICitizen> buyers;

        private Engine()
        {
            buyers = new List<ICitizen>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = reader.ReadLine().Split();

                if (cmdArg.Length == 4)
                {
                    string name = cmdArg[0];
                    int age = int.Parse(cmdArg[1]);
                    string id = cmdArg[2];
                    string birthdate = cmdArg[3];

                    citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else
                {
                    string name = cmdArg[0];
                    int age = int.Parse(cmdArg[1]);
                    string group = cmdArg[2];

                    rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            string cmd;

            while ((cmd = reader.ReadLine()) != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == cmd)
                    {
                        buyer.BuyFood();
                    }
                }            
            }

            writer.WriteLine(buyers.Sum(x=>x.Food).ToString());
        }
    }
}
