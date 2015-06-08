using APIManagmentConsole.Models.Enum;

namespace APIManagmentConsole.Models
{
    public class Subscription
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public ProductState State { get; set; }
        public string SubscriptionId { get; set; }
    }
}
