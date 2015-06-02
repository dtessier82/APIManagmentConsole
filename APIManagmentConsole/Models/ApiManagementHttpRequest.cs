using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManagmentConsole.Models
{
    public class ApiManagementHttpRequest
    {
        public string Description { get; set; }
        public List<ApiManagementParameter> QueryParameters = new List<ApiManagementParameter>();
        public List<ApiManagementParameter> Headers = new List<ApiManagementParameter>();
        public List<ApiManagementRepresentation> Representations = new List<ApiManagementRepresentation>();
    }
}
