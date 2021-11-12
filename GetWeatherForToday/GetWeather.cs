using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetWeather
    {
        HttpClient client = new HttpClient();
        private string url = "https://community-open-weather-map.p.rapidapi.com/find?q=";
        public void GetWeatherForToday(string sity)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + sity + "&cnt=50&mode=null&lon=0&type=link%2C%20accurate&lat=0&units=imperial%2C%20metric");
            request.Headers.Add("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
            request.Headers.Add("x-rapidapi-key", "9f92fb5492msh2e4f028835a7dd7p146468jsn9a7239a6a0d8");
            HttpResponseMessage response = client.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            var repo = JsonConvert.DeserializeObject<GetWeatherResponse>(body);
            Output(repo);
        }
        private void Output(GetWeatherResponse response)
        {
            foreach (var item in response.list)
            {
                Console.WriteLine("Name:" + item.name + " , " + "Max Temp:" + item.main.temp_max + " , " + "Min Temp" + item.main.temp_min + " , " + "Feels like:" + item.main.feels_like + Environment.NewLine);
            }
        }
    }
}
