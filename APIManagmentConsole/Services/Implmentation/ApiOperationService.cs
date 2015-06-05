using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models;
using APIManagmentConsole.Models.Extensions;
using Microsoft.Azure;
using Microsoft.Azure.Management.ApiManagement;

namespace APIManagmentConsole.Services.Implmentation
{
    internal class ApiOperationService : IApiOperationService
    {
        public async Task<Operation> GetAsync(string subcriptionId, string accessToken, string serviceName,
            string resourceGroup, string apiId, string aoId)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(subcriptionId, accessToken));
            var apiOps = await apimClient.ApiOperations.GetAsync(resourceGroup, serviceName, apiId, aoId);

            return apiOps.StatusCode.Equals(HttpStatusCode.OK)
                ? apiOps.Value.ToBusinessModel()
                : null;
        }

    }
}
