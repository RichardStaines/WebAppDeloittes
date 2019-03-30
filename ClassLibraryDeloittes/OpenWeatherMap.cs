using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibraryRestConsumers
{

    public class OpenWeatherMap
    {
        private JsonRestConsumer jsonRestConsumer;

        // http://api.openweathermap.org/data/2.5/weather?q={city name},{country code}
        // http://api.openweathermap.org/data/2.5/weather? q = London, uk

        // this server needs register, and an access key needs to be used to access it.
        private const string URL = "http://api.openweathermap.org/data/2.5/weather"; // TO DO move to config file
        private const string API_KEY = "b6910acdab0d2b731000bbdea40922c8"; // TO DO move to config file
        private const string WEATHER_FIELD_PATH = "weather.[0].description";
        public string weatherForecast { get; }

        // Map any codes that dont match 
        // someone needs to work out where this Rest API doesnt match ISO 3166 
        // I imagine it's EU related - The European Commission generally uses ISO 3166-1 alpha-2 codes with two exceptions: EL (not GR) is used to represent Greece
        // and UK (not GB) is used to represent the United Kingdom.
        private string MapCountryCodes(string countryCode)
        {
            Dictionary<string, string> countryCodeMap = new Dictionary<string, string> { { "GB", "UK" } };

            if (countryCodeMap.ContainsKey(countryCode))
                return countryCodeMap[countryCode];

            return countryCode;
        }

        public OpenWeatherMap(string cityName, string countryCode)
        {
            // Note country code for UK does not match the ones in the other rest service.
            string urlParameters = "?q=" + cityName + "," + MapCountryCodes(countryCode);
            urlParameters += "&APPID=" + API_KEY;

            //jsonRestConsumer = new JsonRestConsumer(URL, urlParameter, API_KEY);  // this API seems to want the key on the url
            jsonRestConsumer = new JsonRestConsumer(URL, urlParameters);

            if (jsonRestConsumer.jsonToken != null)
            {
                // {"coord":{"lon":-0.13,"lat":51.51},"weather":[{"id":300,"main":"Drizzle","description":"light intensity drizzle","icon":"09d"}]...
                // TODO - get real values from API
                weatherForecast = (string)jsonRestConsumer.jsonToken.SelectToken(WEATHER_FIELD_PATH);  
            }
        } // end of constructor

    }
}
