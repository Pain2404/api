using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GetAllTeams
    {
        HttpClient client = new HttpClient();

        public void GetTeams(string id , string year)
        {
            string endpoint = "https://api-football-beta.p.rapidapi.com/teams?league=";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endpoint + id + "&season=" + year);
            request.Headers.Add("x-rapidapi-host", "api-football-beta.p.rapidapi.com");
            request.Headers.Add("x-rapidapi-key", "9f92fb5492msh2e4f028835a7dd7p146468jsn9a7239a6a0d8");
            HttpResponseMessage response = client.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            var repo = JsonConvert.DeserializeObject<GetAllTeamsResponse>(body);
            Output(repo);
        }

        public void GetTeamByName(string name)
        {
            string url = "https://api-football-beta.p.rapidapi.com/teams?name=";
            if (IsThereSpace(name))
            {
                name = name.Replace(" ", "%20");
            }
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + name);
            request.Headers.Add("x-rapidapi-host", "api-football-beta.p.rapidapi.com");
            request.Headers.Add("x-rapidapi-key", "9f92fb5492msh2e4f028835a7dd7p146468jsn9a7239a6a0d8");
            HttpResponseMessage response = client.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            var repo = JsonConvert.DeserializeObject<GetAllTeamsResponse>(body);
            Output(repo);
        }

        private bool IsThereSpace(string name)
        {
            return name.Contains(" ");
        }

        private void Output(GetAllTeamsResponse get)
        {
            foreach (var item in get.response)
            {
                Console.WriteLine($"Team name: {item.team.name}" + " , " + $"Team id: {item.team.id}" + " , " + $"Team founded: {item.team.founded}" + " , " + $"Team country: {item.team.country}"+ Environment.NewLine + $"Venue name: {item.venue.name}" + " , " + $"Venue city: {item.venue.city}" + " , " + $"Venue capacity: {item.venue.capacity}" + " , " + $"Surface: {item.venue.surface}" + Environment.NewLine);
            }
        }
    }
}
