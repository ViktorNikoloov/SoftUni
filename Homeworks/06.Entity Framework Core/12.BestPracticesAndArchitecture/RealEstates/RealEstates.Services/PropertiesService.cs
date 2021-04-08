using RealEstates.Data;
using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;

        public PropertiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(string district, int floor, int maxFloor, int size, int yardSize, int year, string properyType, string buildingType, int price)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
            throw new System.NotImplementedException();
        }
    }
}
