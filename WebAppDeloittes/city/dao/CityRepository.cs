using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDeloittes.city.model;
using WebAppDeloittes.city.api;

namespace WebAppDeloittes.city.dao
{
    public class CityRepository : ICityRepository
    {
        CityContext cityContext;

        public CityRepository() {

            this.cityContext = new CityContext();
        }

        public List<City> SearchCitiesByName(string name)
        {                              
            List<City> cities = cityContext.Cities.Where(c => c.Name == name).ToList();

            return cities;
        }

        /// <summary>
        /// Validate the rating of the city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>errorMsg or blank string</returns>
        private string ValidateRating(City city)
        {
            if (city.Rating < 1 || city.Rating > 5)
                return "Rating must be in the range 1 to 5";
            else
                return "";
        }
        public string AddCity(City city)
        {
            string errorMsg = ValidateRating(city);
            if (!errorMsg.Equals(""))
                return errorMsg;

            cityContext.Cities.Add(city);
            cityContext.SaveChanges();
            return "City successfully deleted";
        }

        public string UpdateCity(City city)
        {
            string errorMsg = ValidateRating(city);
            if (!errorMsg.Equals(""))
                return errorMsg;

            // get city by id
            City cityToUpdate = cityContext.Cities.Find(city.Id);

            cityToUpdate.Rating = city.Rating;
            cityToUpdate.Established = city.Established;
            cityToUpdate.EstimatedPopulation = city.EstimatedPopulation;

            cityContext.SaveChanges();

            return "City successfully updated";
        }

        public string DeleteCity(int id)
        {
            City cityToDelete = new City() { Id = id };
            cityContext.Cities.Attach(cityToDelete);
            cityContext.Cities.Remove(cityToDelete);
            cityContext.SaveChanges();
            return "City successfully deleted";
        }

        /// <summary>
        /// Some useful canned data for trying things out with
        /// </summary>
        /// <returns></returns>        
        public static List<City> GetTestCityList()
        {
            City[] cities =
            {
                    new City()
                    {
                        Name = "Chepstow", Country = "United Kingdom", State = "Gwent", Rating = 5,
                        Established = new DateTime(486, 01, 01), EstimatedPopulation = 20000
                    },
                    new City()
                    {
                        Name = "London", Country = "United Kingdom", State = "London", Rating = 4,
                        Established = new DateTime(146, 01, 01), EstimatedPopulation = 12000000
                    },
                    new City()
                    {
                        Name = "London", Country = "Canada", State = "Ontario", Rating = 3,
                        Established = new DateTime(1945, 01, 01), EstimatedPopulation = 120000
                    },

                    new City()
                    {
                        Name = "Swindon", Country = "United Kingdom", State = "Swindow", Rating = 1,
                        Established = new DateTime(1852, 01, 01), EstimatedPopulation = 50000
                    },
                    new City()
                    {
                        Name = "Birmingham", Country = "United Kingdom", State = "Midlands", Rating = 4,
                        Established = new DateTime(1953, 01, 01), EstimatedPopulation = 1000000
                    },
                    new City()
                    {
                        Name = "Cardiff", Country = "United Kingdom", State = "Glamorgan", Rating = 4,
                        Established = new DateTime(1102, 01, 01), EstimatedPopulation = 250000
                    }
            };
            return new List<City>(cities);
        }
    }
}
