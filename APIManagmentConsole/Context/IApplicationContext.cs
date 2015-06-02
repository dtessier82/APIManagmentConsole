using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Context
{
    public interface IApplicationContext
    {
        ISecurityContext GetSecurityContext();
        string GetClientId();
        string GetLoginUrl();
        string GetAPIUrl();
        void SetSecurityContext(ISecurityContext securityContext);
    }
}
