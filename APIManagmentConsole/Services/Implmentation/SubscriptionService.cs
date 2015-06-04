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
            return list.StatusCode == HttpStatusCode.OK ? 
                list.Subscriptions.Select(sub => sub.ToBusinessModel()).ToList() 
                : new List<Subscription>();
        }
    }
}
