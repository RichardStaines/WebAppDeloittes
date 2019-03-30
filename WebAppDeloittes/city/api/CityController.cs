using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppDeloittes.city.model;
using WebAppDeloittes.city.dao;
using ClassLibraryRestConsumers;

namespace WebAppDeloittes.city.api
{
    [Route("api/[Controller]")]
    public class CityController : Controller
    {
        private CityRepository cityRepository;
       
        public CityController()
        {
            cityRepository = new CityRepository();
        }


        [HttpPost]
        public string Post(City city)
        {            
            return cityRepository.AddCity(city);
        }

        [HttpPut]
        public string Put(City city) 
        {
            // update the city in the DB
            return cityRepository.UpdateCity(city);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return cityRepository.DeleteCity(id);
        }

        private List<CityView> EnrichCities(List<City> cities)
        {
            List<CityView> cityViews = new List<CityView>();

            foreach (City city in cities)
            {
                CityView cityView = new CityView(city);

                CountryRestConsumer countryRestConsumer = new CountryRestConsumer(city.Country);

                // lets get the country codes
                cityView.Country2Code = countryRestConsumer.alpha2;
                cityView.Country3Code = countryRestConsumer.alpha3;

                OpenWeatherMap weatherRestConsumer = new OpenWeatherMap(cityView.Name, cityView.Country2Code);
                cityView.Weather = weatherRestConsumer.weatherForecast;

                cityViews.Add(cityView);
            }
            return cityViews;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            List<City> cities = cityRepository.SearchCitiesByName(name);
            List<CityView> cityViews = EnrichCities(cities);

            return new JsonResult(cityViews,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                });
        }

        [HttpGet("test-data")]
        public IActionResult Get()
        {
            List<City> cities = CityRepository.GetTestCityList();
            List<CityView> cityViews = EnrichCities(cities);

            return new JsonResult(cityViews,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                });
        }


    }
}
