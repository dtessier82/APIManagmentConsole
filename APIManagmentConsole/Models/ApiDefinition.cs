using System.Collections.Generic;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models
{
    public class ApiDefinition
    {
        public string Id { get; set; }
        public string IdPath { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string ServiceUrl { get; set; }
        public string Path { get; set; }
        public List<ApiProtocolContract> Protocols { get; set; }
        public SubscriptionKeyParameterNamesContract SubscriptionKeyParameter { get; set; }
        public List<Operation> Operations { get; set; } 
        public ApiDefinition()
        {
            Protocols = new List<ApiProtocolContract>();
            SubscriptionKeyParameter = new SubscriptionKeyParameterNamesContract();
            Operations = new List<Operation>();
        }
    }
}
