using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDeloittes.city.model;

namespace WebAppDeloittes.city.api
{
    public class CityView
    {
        public CityView(City city)
        {
            this.Id = city.Id;
            this.Name = city.Name;
            this.State = city.State;
            this.Country = city.Country;
            this.Rating = city.Rating;
            this.Established = city.Established;
            this.EstimatedPopulation = city.EstimatedPopulation;

            this.Country2Code = "Unknown";
            this.Country3Code = "Unknown";
            this.Weather = "Unkown";
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int Rating { get; set; } 

        public DateTime Established { get; set; }

        public long EstimatedPopulation { get; set; }

        public string Country2Code { get; set; }
        public string Country3Code { get; set; }
        public string Weather { get; set; }
    }
}
