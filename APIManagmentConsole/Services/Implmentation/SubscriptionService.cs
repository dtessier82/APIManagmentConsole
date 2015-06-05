using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIManagmentConsole.Models;
using APIManagmentConsole.Models.Extensions;
using Microsoft.Azure;
using Microsoft.Azure.Subscriptions;

namespace APIManagmentConsole.Services.Implmentation
{
    public class SubscriptionService : ISubscriptionService
    {
        public async Task<List<Subscription>> GetSubscriptions(string tenantId, string token)
        {
            var subClient = new SubscriptionClient(new TokenCloudCredentials(tenantId, token));
            var list = await subClient.Subscriptions.ListAsync();
            if (list.StatusCode == HttpStatusCode.OK)
            {
                return list.Subscriptions.Where(
                        item => item.DisplayName.EndsWith("API") || item.DisplayName.Equals("Development2"))
                        .Select(item=>item.ToBusinessModel()).ToList();
            }

            return new List<Subscription>();
        }
    }
}
