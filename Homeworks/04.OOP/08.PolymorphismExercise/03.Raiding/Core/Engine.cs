using System;
using System.Collections.Generic;
using System.Linq;

using _03.Raiding.Core.Contracts;
using _03.Raiding.Factories;
using _03.Raiding.IO.Contracts;
using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IHero> raid;
        private readonly HeroFactory heroFactory;

        private IHero hero;

        private Engine()
        {
            hero = null;
            raid = new List<IHero>();
            heroFactory = new HeroFactory();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            while(n > raid.Count)
            {
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();

                try
                {
                    hero = heroFactory.CreatHero(heroName, heroType);

                    if (hero != null)
                    {
                        raid.Add(hero);
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }

            }
            int bossPower = int.Parse(reader.ReadLine());
            int heroesPower = raid.Sum(x => x.Power);

            CastAllAbilities();

            writer.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");
        }

        private void CastAllAbilities()
        {
            foreach (var hero in raid)
            {
                writer.WriteLine(hero.CastAbility());
            }

        }
    }
}
