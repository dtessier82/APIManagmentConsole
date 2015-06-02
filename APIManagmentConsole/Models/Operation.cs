using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Models
{
    public class Operation
    {
        public string Name { get; set; }
        public string Method { get; set; }
        public string UrlTemplate { get; set; }
        public List<ApiManagementParameter> TemplateParameters = new List<ApiManagementParameter>();
        public string Description { get; set; }
        public ApiManagementHttpRequest Request { get; set; }
        public List<ApiManagementHttpResponse> Responses = new List<ApiManagementHttpResponse>();
    }
}
