using APIManagmentConsole.Models.Enum;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Terms { get; set; }
        public int? SubscriptionsLimit { get; set; }
        public bool? ApprovalRequired { get; set; }
        public ProductState State { get; set; }
        public bool? SubscriptionRequired { get; set; }
        public string IdPath { get; set; }

        public string StateDescription { get { return State.ToString(); } }
        
    }
}
