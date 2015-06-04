using System.Collections.Generic;

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
