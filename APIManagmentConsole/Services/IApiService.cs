using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models;

namespace APIManagmentConsole.Services
{
    public interface IApiService
    {
        Task<List<ApiDefinition>> ListProductApisAsync(string subcriptionId, string accessToken, string serviceName, string resourceGroup,
           string productId);

        Task<ApiDefinition> GetAsync(string subcriptionId, string accessToken, string serviceName, string resourceGroup,
           string apiId);

        Task<string> SwaggerExport(string subcriptionId, string accessToken, string serviceName, string resourceGroup,
           string apiId);

        Task<List<Operation>> ListApiOperationsAsync(string subcriptionId, string accessToken, string serviceName,
            string resourceGroup,
            string apiId);

    }
}
