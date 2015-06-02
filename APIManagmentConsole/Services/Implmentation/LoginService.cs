using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIManagmentConsole.Context;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace APIManagmentConsole.Services.Implmentation
{
    public class LoginService : ILoginService
    {
        public async Task<Boolean> Login(string userName, SecureString password)
        {
            var passwordBSTR = default(IntPtr);
            var insecurePass = "";
            passwordBSTR = Marshal.SecureStringToBSTR(password);
            insecurePass = Marshal.PtrToStringBSTR(passwordBSTR);
            var credent = new UserCredential(userName, insecurePass);

            var authority = new Uri(string.Format(App.GetApplicationContext().GetLoginUrl(), "aosoftwareservicesdelphi.onmicrosoft.com"));
            var context = new AuthenticationContext(authority.AbsoluteUri, false);
            var result = await context.AcquireTokenAsync(resource: App.GetApplicationContext().GetAPIUrl(),
                clientId: App.GetApplicationContext().GetClientId(), userCredential: credent);

            if (result != null)
            {
                App.GetApplicationContext()
                    .SetSecurityContext(new ApplicationSecurityContext(userName, result.AccessToken, result.TenantId));
                return true;
            }

            return false;

        }
    }
}
