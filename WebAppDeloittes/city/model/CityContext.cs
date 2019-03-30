using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAppDeloittes.city.dao;

namespace WebAppDeloittes.city.model
{
    public class CityContext: DbContext
    {
        public CityContext() : base()
        { }

        public DbSet<City> Cities { get; set; }

        public static void CreateTestData()
        {
            using (var ctx = new CityContext())
            {
                List<City> cities = CityRepository.GetTestCityList();
                foreach (City city in cities)
                    ctx.Cities.Add(city);
                ctx.SaveChanges();
            }
        }

    }

}
