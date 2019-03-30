using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibraryRestConsumers
{
    public class JsonRestConsumer
    {
        public JToken jsonToken { get; }

        public JsonRestConsumer(string urlRequest, string urlParameters, string apiKey=null)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlRequest);

            if (apiKey != null)
                client.DefaultRequestHeaders.Add("api-key", apiKey);

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

