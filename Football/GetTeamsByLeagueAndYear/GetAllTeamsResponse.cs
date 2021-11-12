using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GetAllTeamsResponse
    {
        public string id { get; set; }
        public AllTeams[] response { get; set; }
    }
}
