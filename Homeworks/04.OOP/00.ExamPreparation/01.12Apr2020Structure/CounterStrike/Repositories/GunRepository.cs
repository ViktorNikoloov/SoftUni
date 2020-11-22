﻿using System;
using System.Collections.Generic;
using System.Linq;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> guns;

        public IReadOnlyCollection<IGun> Models
            => (IReadOnlyCollection<IGun>)guns;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            guns.Add(model);
        }

        public IGun FindByName(string name)
        => guns.FirstOrDefault(g => g.Name == name);

        public bool Remove(IGun model)
        => guns.Remove(model);
       
    }
}
