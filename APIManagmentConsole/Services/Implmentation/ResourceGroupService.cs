using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Services.Implmentation
{
    public class ResourceGroupService : IResourceGroupService
    {
        public async Task<List<GenericResourceExtended>> ListAsync(string tenantId, string accessToken)
        {
            var resClient = new ResourceManagementClient(new TokenCloudCredentials(tenantId, accessToken));
            var list = await resClient.Resources.ListAsync(null);
            if (list.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return list.Resources.ToList();
            }
            return null;
        }
    }
}
