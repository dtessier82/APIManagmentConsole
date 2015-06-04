using System.Collections.Generic;
using APIManagmentConsole.Models.Enum;
using APIManagmentConsole.Models.Extensions;

namespace APIManagmentConsole.Models
{
    public class Policy
    {
        public PolicyType Type { get; set; }
        public PolicyLocality Locality { get; set; }
        public Dictionary<string, string> Attributes = new Dictionary<string, string>();
        public List<PolicyElement> Elements = new List<PolicyElement>();

        public string TypeString
        {
            get { return Type.ToPolicyString(); }
        }

       
    }

}
