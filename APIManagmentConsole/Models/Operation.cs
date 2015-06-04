using System.Collections.Generic;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models
{
    public class Operation
    {
        public string Id { get; set; }
        public string IdPath { get; set; }
        public string ApiId { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string UrlTemplate { get; set; }
        public List<ParameterContract> TemplateParameters = new List<ParameterContract>();
        public string Description { get; set; }
        public RequestContract Request { get; set; }
        public List<ResponseContract> Responses = new List<ResponseContract>();
    }
}
