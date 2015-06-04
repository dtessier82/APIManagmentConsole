using System;
using System.Security;
using System.Threading.Tasks;

namespace APIManagmentConsole.Services
{
    public interface ILoginService
    {
        Task<Boolean> Login(string userName, SecureString password);
    }
}
