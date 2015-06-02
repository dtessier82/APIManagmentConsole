using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Terms { get; set; }
        public int? SubscriptionsLimit { get; set; }
        public bool ApprovalRequired { get; set; }
        public string State { get; set; }
    }
}
