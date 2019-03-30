using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibraryDeloitte
{
    
    public class CountryRestConsumer
    {
        private const string URL = "https://restcountries.eu/rest/v2/name";
        public JToken jsonToken { get; }
        public string alpha2 { get;  }
        public string alpha3 { get; }

        public CountryRestConsumer(string countryName)
        {
            string urlRequest = URL + "/" + countryName;
            string urlParameters = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlRequest);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                String sContent = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                                                                                //                sContent = sContent.Replace('[', ' ');                                                                               //                sContent = sContent.Replace(']', ' ');
                jsonToken = JToken.Parse(sContent);
                
                alpha2 = (string)jsonToken.SelectToken("[0].alpha2Code");
                alpha3 = (string)jsonToken.SelectToken("[0].alpha3Code");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        } // end of constructor
    } 
    
}
