using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIManagmentConsole.Models;
using APIManagmentConsole.Models.Extensions;
using Microsoft.Azure;
using Microsoft.Azure.Management.ApiManagement;

namespace APIManagmentConsole.Services.Implmentation
{
    public class ApiService : IApiService
    {
        public async Task<List<ApiDefinition>> ListProductApisAsync(string tenant, string accessToken, string serviceName, string resourceGroup,
          string productId)
        {

            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenant, accessToken));
            var productApis = await apimClient.ProductApis.ListAsync(resourceGroup, serviceName, productId, null);

            return productApis.StatusCode.Equals(HttpStatusCode.OK)
                ? productApis.Result.Values.Select(api => api.ToBusinessModel()).ToList()
                : null;
        }


        public async Task<ApiDefinition> GetAsync(string subcriptionId, string accessToken, string serviceName, string resourceGroup, string apiId)
        {
            ApiDefinition apiDefinition = null;

            var apimClient = new ApiManagementClient(new TokenCloudCredentials(subcriptionId, accessToken));
            var api = await apimClient.Apis.GetAsync(resourceGroup, serviceName, apiId, new CancellationToken(false));

            if (!api.StatusCode.Equals(HttpStatusCode.OK)) 
                return apiDefinition;

            apiDefinition = api.Value.ToBusinessModel();
            var apiOps = await apimClient.ApiOperations.ListAsync(resourceGroup, serviceName, apiId, null);
            if (apiOps.StatusCode.Equals(HttpStatusCode.OK))
            {
                apiDefinition.Operations =
                    await ListApiOperationsAsync(subcriptionId, accessToken, serviceName, resourceGroup, apiId);
            }

            return apiDefinition;
        }

        public async Task<List<Operation>> ListApiOperationsAsync(string subcriptionId, string accessToken, string serviceName,
            string resourceGroup,
            string apiId)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(subcriptionId, accessToken));
            var apiOps = await apimClient.ApiOperations.ListAsync(resourceGroup, serviceName, apiId, null);

            return apiOps.StatusCode.Equals(HttpStatusCode.OK) ? 
                apiOps.Result.Values.Select(aio => aio.ToBusinessModel()).ToList() : new List<Operation>();
        }

        public async Task<string> SwaggerExport(string subcriptionId, string accessToken, string serviceName, string resourceGroup,
            string apiId)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(subcriptionId, accessToken));
            var api = await apimClient.Apis.ExportAsync(resourceGroup, serviceName, apiId, "application/json", new CancellationToken(false));

            return api.StatusCode.Equals(HttpStatusCode.OK) ? Encoding.UTF8.GetString(api.Content) : null;
        }
    }
}
