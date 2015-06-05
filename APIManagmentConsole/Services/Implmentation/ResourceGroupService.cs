using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIManagmentConsole.Models;
using APIManagmentConsole.Models.Extensions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using ResourceGroup = APIManagmentConsole.Models.ResourceGroup;

namespace APIManagmentConsole.Services.Implmentation
{
    public class ResourceGroupService : IResourceGroupService
    {
        public async Task<List<ResourceGroup>> ListAsync(string tenantId, string accessToken)
        {
            var resClient = new ResourceManagementClient(new TokenCloudCredentials(tenantId, accessToken));
            var list = await resClient.ResourceGroups.ListAsync(null);
            if (list.StatusCode == HttpStatusCode.OK)
            {
                return list.ResourceGroups.ToList().Where(item => item.Name.StartsWith("Api"))
                    .Select(resource => resource.ToBusinessModel()).ToList();
            }
            return new List<ResourceGroup>();
        }


        public async Task<List<Resource>> ListApiManagementResourcesAsync(string tenantId, string accessToken, string resourceGroupName)
        {
            var resClient = new ResourceManagementClient(new TokenCloudCredentials(tenantId, accessToken));
            var list = await resClient.Resources.ListAsync(new ResourceListParameters
            {
                ResourceType = "Microsoft.ApiManagement/service",
                ResourceGroupName = resourceGroupName
            });

            return list.StatusCode == HttpStatusCode.OK ?
                list.Resources.ToList().Select(resource => resource.ToBusinessModel()).ToList()
                : new List<Resource>();
        }
    }
}
