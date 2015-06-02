using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Models
{
    public class ProductTemplate : Product
    {
        public string Id { get; set; }

        public Dictionary<string, ApiDefinitionTemplate> ApiDefinitions = new Dictionary<string, ApiDefinitionTemplate>();
        public Dictionary<string, Object> Properties = new Dictionary<string, Object>(StringComparer.InvariantCultureIgnoreCase);

        public List<string> Groups = new List<string>();
        public string Policy { get; set; }
    }
}
