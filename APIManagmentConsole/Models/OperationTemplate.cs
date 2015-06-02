using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManagmentConsole.Models
{
    public class OperationTemplate : Operation
    {
        public string Id { get; set; }
        public Dictionary<string, Object> Properties = new Dictionary<string, Object>(StringComparer.InvariantCultureIgnoreCase);

        public Operation OperationBody
        {
            get
            {
                return new Operation
                {
                    Name = Name,
                    Description = Description,
                    Method = Method,
                    UrlTemplate = UrlTemplate,
                    TemplateParameters = TemplateParameters,
                    Request = Request,
                    Responses = Responses
                };
            }
        }

        public string Policy { get; set; }
    }
}
