using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetBIO
    {
        private static HttpClient client = new HttpClient();
        private string endpoint = "https://imdb8.p.rapidapi.com/actors/get-bio?nconst=";

        public void GetBioByActor(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endpoint + id);
            request.Headers.Add("X-RapidAPI-Host", "imdb8.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "9f92fb5492msh2e4f028835a7dd7p146468jsn9a7239a6a0d8");
            HttpResponseMessage response = client.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            var repo = JsonConvert.DeserializeObject<Bio>(body);
            Output(repo);
        }
        private void Output(Bio bio)
        {
            Console.WriteLine("Real Name:" + bio.realName + " , " + "BirthDate:" + bio.birthDate + " , " + "Name:" + bio.name + " , " + "Gender:" + bio.gender + " , " + "BirthPlace:" + bio.birthPlace + Environment.NewLine);
        }
    }
}
