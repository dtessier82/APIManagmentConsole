using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManagmentConsole.Models
{
    public class ApiManagementHttpResponse
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public List<ApiManagementRepresentation> Representations = new List<ApiManagementRepresentation>();
    }
}
