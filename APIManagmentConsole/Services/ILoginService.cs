using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Context;

namespace APIManagmentConsole.Services
{
    public interface ILoginService
    {
        Task<Boolean> Login(string userName, SecureString password);
    }
}
