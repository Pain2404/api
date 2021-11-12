using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetWeatherResponse
    {
        public string id { get; set; }
        public Weather[] list { get; set; }
    }
}
