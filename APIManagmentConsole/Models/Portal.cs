using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Models
{
    public class Portal
    {
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string ServiceUrl { get; set; }
        public string ApiUrl { get; set; }

        public string AccessToken { get; set; }
    }
}
