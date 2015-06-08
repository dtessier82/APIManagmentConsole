using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Models.Enum
{
    public enum UserState
    {
        [Description("Active")]
        Active,
        [Description("Blocked")]
        Blocked,
    }
}
