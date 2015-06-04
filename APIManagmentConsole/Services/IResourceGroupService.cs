
using System.Collections.Generic;
using System.Threading.Tasks;
using APIManagmentConsole.Models;

namespace APIManagmentConsole.Services
{
    public interface IResourceGroupService
    {
        Task<List<ResourceGroup>> ListAsync(string tenantId, string accessToken);
        Task<List<Resource>> ListApiManagementResourcesAsync(string tenantId, string accessToken, string resourceGroupName);
    }
}
