using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models;

namespace APIManagmentConsole.Services
{
    public interface IApiOperationService
    {
        Task<Operation> GetAsync(string subcriptionId, string accessToken, string serviceName, string resourceGroup, string apiId, string aoId);
    }
}
