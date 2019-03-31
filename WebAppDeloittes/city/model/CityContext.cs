using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAppDeloittes.city.dao;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace WebAppDeloittes.city.model
{
    public class CityContext: DbContext
    {
        public CityContext() : base()
        { }


        public DbSet<City> Cities { get; set; }

    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
  

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
