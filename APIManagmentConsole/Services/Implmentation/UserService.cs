using Microsoft.Azure.Management.ApiManagement;
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

namespace APIManagmentConsole.Services.Implmentation
{
    public class UserService : IUserService
    {
        public async Task<List<User>> ListAysnc(string tenantId, string accessToken, string resourceGroup, string serviceName)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenantId, accessToken));
            var users = await apimClient.Users.ListAsync(resourceGroup, serviceName, null);

            return users.StatusCode.Equals(HttpStatusCode.OK)
                ? users.Result.Values.Select(user => user.ToBusinessModel("")).ToList()
                : new List<User>();
        }

        public async Task<User> GetAsync(string tenantId, string accessToken, string resourceGroup, string serviceName,
            string userId)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenantId, accessToken));
            var user = await apimClient.Users.GetAsync(resourceGroup, serviceName, userId, new CancellationToken());

            return user.StatusCode.Equals(HttpStatusCode.OK)
                ? user.Value.ToBusinessModel(user.ETag)
                : null;
        }

        public async Task<List<Group>> ListUserGroupsAsync(string tenantId, string accessToken, string resourceGroup,
            string serviceName, string userId)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenantId, accessToken));
            var userGroups = await apimClient.UserGroups.ListAsync(resourceGroup, serviceName, userId, null, new CancellationToken());
            return userGroups.StatusCode.Equals(HttpStatusCode.OK)
               ? userGroups.Result.Values.Select(user => user.ToBusinessModel()).ToList()
               : new List<Group>();
        }


        public async Task<bool> DeleteAsync(string tenantId, string accessToken, string resourceGroup, string serviceName, string userId, string etag, bool deleteSubscriptions)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenantId, accessToken));
            var users = await apimClient.Users.DeleteAsync(resourceGroup, serviceName, userId, etag, deleteSubscriptions);

            return users.StatusCode.Equals(HttpStatusCode.NoContent);
        }

        public async Task<bool> UpdateAsync(string tenantId, string accessToken, string resourceGroup, string serviceName, User user)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenantId, accessToken));

            var updateUser = user.ToUpdateModel();
            if (user.IsPasswordProvided)
                updateUser.Password = user.Password;

            var response = await apimClient.Users.UpdateAsync(resourceGroup, serviceName, user.Id, updateUser, user.ETag);

            return response.StatusCode.Equals(HttpStatusCode.NoContent);

        }
    }
}
