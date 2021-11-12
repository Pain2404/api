using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetAllFilmography
    {
        private static HttpClient client = new HttpClient();
        private string endpoint = "https://imdb8.p.rapidapi.com/actors/get-all-filmography?nconst=";

        public void AllMovieByActor(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endpoint + id);
            request.Headers.Add("X-RapidAPI-Host", "imdb8.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "9f92fb5492msh2e4f028835a7dd7p146468jsn9a7239a6a0d8");
            HttpResponseMessage response = client.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            var repo =  JsonConvert.DeserializeObject<GetAllFilmographyResponse>(body);
            Output(repo);
        }
        private void Output(GetAllFilmographyResponse response)
        {
            foreach (var get in response.filmography)
            {
                if (get.status == "released")
                {
                    Console.WriteLine("Title:" + get.title + " , " + "Status:" + get.status + " , " + "TitleType:" + get.titleType + " , " + "Year:" + get.year + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("Title:" + get.title + " , " + "Status:" + get.status + " , " + "TitleType:" + get.titleType + Environment.NewLine);
                }
            }

        }
    }
}
