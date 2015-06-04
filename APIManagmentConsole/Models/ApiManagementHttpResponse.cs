using System.Collections.Generic;

namespace APIManagmentConsole.Models
{
    public class ApiManagementHttpResponse
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public List<ApiManagementRepresentation> Representations = new List<ApiManagementRepresentation>();
    }
}
