using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models.Enum;

namespace APIManagmentConsole.Models
{
    public class Subscription
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public State State { get; set; }
        public string SubscriptionId { get; set; }
    }
}
