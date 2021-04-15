﻿using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;

        public PropertiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(string district, int price,
            int floor, int maxFloor, int size, int yardSize,
            int year, string properyType, string buildingType)
        {
            var property = new Property
            {
                Size = size,
                Price = price <= 0 ? null : price,
                Floor = floor <= 0 || floor > 255? null : (byte)floor,
                TotalFloor = maxFloor <= 0 || maxFloor > 255 ? null : (byte)maxFloor,
                YardSize = yardSize <= 0 ? null : yardSize,
                Year = year <= 1800 ? null : year,
            };

            var dbDistrict = dbContext.Districts.FirstOrDefault(x => x.Name == district);
            if (dbDistrict == null)
            {
                dbDistrict = new District
                {
                    Name = district
                };
            }
            property.District = dbDistrict;

            var dbPropertyType = dbContext.PropertyTypes.FirstOrDefault(x => x.Name == properyType);
            if (dbPropertyType == null)
            {
                dbPropertyType = new PropertyType
                {
                    Name = properyType
                };
            }
            property.Type = dbPropertyType;

            var dbBuildingType = dbContext.Buildings.FirstOrDefault(x => x.Name == buildingType);
            if (dbBuildingType == null)
            {
                dbBuildingType = new BuildingType
                {
                    Name = buildingType
                };
            }
            property.BuildingType = dbBuildingType;

            dbContext.Properties.Add(property);
            dbContext.SaveChanges();
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
           var properties = dbContext
                .Properties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice && x.Size >= minSize && x.Size <= maxSize)
                .Select(x=> new PropertyInfoDto
                {
                    Size = x.Size,
                    Price = x.Price ?? 0,
                    BuildingType = x.BuildingType.Name,
                    DistrictName = x.District.Name,
                    PropertyType = x.Type.Name
                })
                .ToList();

            return properties;
        }
    }
}
