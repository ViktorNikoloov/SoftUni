using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public void Add(ICar model)
        {
            models.Add(model);
        }

        public bool Remove(ICar model)
        => models.Remove(model);

        public ICar GetByName(string name)
        => models.FirstOrDefault(n => n.Model == name);

        public IReadOnlyCollection<ICar> GetAll()
        => (IReadOnlyCollection<ICar>)models;

    }
}
