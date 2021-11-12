using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetAllFilmographyResponse
    {
        public string id { get; set; }
        public Movie[] filmography { get; set; }
    }
}
