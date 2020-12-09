using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private ICollection<IDriver> models;

        public DriverRepository()
        {
            models = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            models.Add(model);
        }

        public bool Remove(IDriver model)
        => models.Remove(model);

        public IDriver GetByName(string name)
        => models.FirstOrDefault(n => n.GetType().Name == name);

        public IReadOnlyCollection<IDriver> GetAll()
        => (IReadOnlyCollection<IDriver>)models;

    }
}
