using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models;

namespace APIManagmentConsole.Services
{
    public interface IUserService
    {
        Task<List<User>> ListAysnc(string tenantId, string accessToken, string resourceGroup, string serviceName);
        Task<bool> DeleteAsync(string tenantId, string accessToken, string resourceGroup, string serviceName, string userId, string etag, bool deleteSubscriptions);
        Task<User> GetAsync(string tenantId, string accessToken, string resourceGroup, string serviceName, string userId);
        Task<List<Group>> ListUserGroupsAsync(string tenantId, string accessToken, string resourceGroup,string serviceName, string userId);
        Task<bool> UpdateAsync(string tenantId, string accessToken, string resourceGroup, string serviceName, User user);

    }
}
