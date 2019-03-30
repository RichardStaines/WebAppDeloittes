using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ClassLibraryRestConsumers;

namespace ClassLibraryRestConsumers
{
    
    public class CountryRestConsumer
    {
        private JsonRestConsumer jsonRestConsumer;

        private const string URL = "https://restcountries.eu/rest/v2/name"; // TO DO move to config file
        private const string COUNTRY_CODE_2_PATH = "[0].alpha2Code"; // TO DO move to config file
        private const string COUNTRY_CODE_3_PATH = "[0].alpha3Code"; // TO DO move to config file
        public string alpha2 { get;  }
        public string alpha3 { get; }

        public CountryRestConsumer(string countryName)
        {
            string urlRequest = URL + "/" + countryName;            

            jsonRestConsumer = new JsonRestConsumer(urlRequest, "");
            if (jsonRestConsumer.jsonToken != null)
            {
                alpha2 = (string)jsonRestConsumer.jsonToken.SelectToken(COUNTRY_CODE_2_PATH);
                alpha3 = (string)jsonRestConsumer.jsonToken.SelectToken(COUNTRY_CODE_3_PATH);
            }
        } // end of constructor
    } 
    
}
