using Microsoft.Azure.Management.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Services
{
    public interface IResourceGroupService
    {
        Task<List<GenericResourceExtended>> ListAsync(string tenantId, string accessToken);
    }
}
