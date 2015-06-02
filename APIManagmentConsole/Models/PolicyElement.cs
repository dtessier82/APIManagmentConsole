using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManagmentConsole.Models
{
    public class PolicyElement
    {
        public Dictionary<string, string> Attributes = new Dictionary<string, string>();
        public KeyValuePair<string, object> Value { get; set; }
        public KeyValuePair<string, object> SetValue(string name, object value)
        {
            Value = new KeyValuePair<string, object>(name, value);
            return Value;
        }
    }
}
