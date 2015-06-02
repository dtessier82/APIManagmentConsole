using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Models
{
    public class ApiDefinition
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string ServiceUrl { get; set; }
        public string Path { get; set; }
        public List<string> Protocols = new List<string>();
    }
}
