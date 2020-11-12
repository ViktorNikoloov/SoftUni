using System.Collections.Generic;

using _04.BorderControl.IO.Contracts;
using _04.BorderControl.Models;
using _04.BorderControl.Models.Contracts;

namespace _04.BorderControl.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        ICollection<IIdentifiable> identities;

        private Engine()
        {
            identities = new List<IIdentifiable>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split();

                if (cmdArg.Length == 3)
                {
                    string name = cmdArg[0];
                    int age = int.Parse(cmdArg[1]);
                    string id = cmdArg[2];

                    ICitizen citizen = new Citizen(name, age, id);
                    identities.Add(citizen);
                }
                else
                {
                    string model = cmdArg[0];
                    string id = cmdArg[1];

                    IRobot robot = new Robot(model, id);
                    identities.Add(robot);
                }

            }

            string fakeId = reader.ReadLine();

            foreach (var identity in identities)
            {
                //string idLastTreeNumbers = identity.Id.EndsWith(fakeId);

                string idLastTreeNumbers = identity.Id.Substring(identity.Id.Length - fakeId.Length);

                if (idLastTreeNumbers == fakeId)
                {
                    writer.WriteLine(identity.Id);
                }
            }

            //If you want to use this, you will need using System.Linq;

            //identities.Where(c => c.Id.EndsWith(fakeId))
            //.Select(c => c.Id)
            //.ToList()
            //.ForEach(writer.WriteLine);
        }
    }
}
