using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManagmentConsole.Models
{
    public class ApiManagementParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DefaultValue { get; set; }
        public bool Required { get; set; }
        public List<string> Values = new List<string>();
    }
}
