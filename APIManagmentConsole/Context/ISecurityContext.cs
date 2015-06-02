using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Context
{
    public interface ISecurityContext
    {
        string GetAccessToken();
        string GetCurrentUser();
        string GetTenantId();
    }
}
