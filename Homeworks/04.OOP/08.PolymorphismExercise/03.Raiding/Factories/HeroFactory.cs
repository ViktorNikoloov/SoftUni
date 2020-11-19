using _03.Raiding.Common;
using _03.Raiding.Models;
using _03.Raiding.Models.Contracts;
using System;

namespace _03.Raiding.Factories
{
    public class HeroFactory
    {
        public IHero CreatHero(string heroName, string heroType)
        {
            IHero hero = null;

            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }

            if (hero == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidHeroMsg);
            }
            
            return hero;
        }
    }
}
