using System;
using System.Collections.Generic;

namespace APIManagmentConsole.Models
{
    public class ApiDefinitionTemplate : ApiDefinition
    {
        public string Id { get; set; }
        public List<OperationTemplate> Operations = new List<OperationTemplate>();
        public Dictionary<string, Object> Properties = new Dictionary<string, Object>(StringComparer.InvariantCultureIgnoreCase);

        public string Policy { get; set; }
    }

}
