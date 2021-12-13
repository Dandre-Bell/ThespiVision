using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ThespiVision.Models;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ThespiVision.Controllers
{

    class ShowApiController
    {
        // GET: api/<ValuesController>
        
        public static async Task<ObservableCollection<Show>> Get()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);
            var uri = new Uri("https://thespiwebapi.azure-api.net/");
            var response = await client.GetAsync(uri).ConfigureAwait(false);

            ObservableCollection<Show> savedShowList = null;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                savedShowList = JsonConvert.DeserializeObject<ObservableCollection<Show>>(content);
            }

            Console.WriteLine("serving get response");
            return savedShowList;
        }

        // GET api/<ValuesController>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        public static async Task<bool> Post( string title, string company, string loaction, string description, DateTime open, DateTime close)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);
            var uri = new Uri("https://thespiwebapi.azure-api.net/");
            var content = new StringContent(JsonConvert.SerializeObject(new Show(title, company, loaction, description, open, close), Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        // PUT api/<ValuesController>/5
        
        public void Put(int id, string value)
        {
        }

        // DELETE api/<ValuesController>/5

        public static async Task<bool> Delete(Guid id)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);

            var uri = new Uri("https://thespiwebapi.azure-api.net/?id=" + id);

            var response = await client.DeleteAsync(uri).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }
    }
}
