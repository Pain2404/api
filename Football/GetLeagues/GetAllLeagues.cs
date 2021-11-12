using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetAllLeagues
    {
        HttpClient client = new HttpClient();
        private string endpoint = "https://api-football-beta.p.rapidapi.com/leagues";

        public void AllLeagues()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Add("x-rapidapi-host", "api-football-beta.p.rapidapi.com");
            request.Headers.Add("x-rapidapi-key", "9f92fb5492msh2e4f028835a7dd7p146468jsn9a7239a6a0d8");
            HttpResponseMessage response = client.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            var repo = JsonConvert.DeserializeObject<GetLeaguesResponse>(body);
            Output(repo);
        }
        private void Output(GetLeaguesResponse get)
        {
            foreach (var item in get.response)
            {
                Console.WriteLine("Name: " + item.league.name + " , " + "Country: " + item.country.name + " , " + "Type: " + item.league.type + " , " + "Id: " + item.league.id + Environment.NewLine);
            }
        }
    }
}
