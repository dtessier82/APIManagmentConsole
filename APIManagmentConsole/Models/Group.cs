using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models
{
    public class Group
    {
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public string IdPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool SystemGroup { get; set; }
        public GroupTypeContract Type { get; set; }

    }
}
