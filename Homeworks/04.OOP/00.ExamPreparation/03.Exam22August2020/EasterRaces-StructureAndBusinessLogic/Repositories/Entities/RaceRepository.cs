using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public bool Remove(IRace model)
        => models.Remove(model);

        public IRace GetByName(string name)
        => models.FirstOrDefault(n => n.Name == name);

        public IReadOnlyCollection<IRace> GetAll()
        => (IReadOnlyCollection<IRace>)models;
    }
}
