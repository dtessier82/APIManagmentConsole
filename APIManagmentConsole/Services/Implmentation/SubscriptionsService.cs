using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models;
using Microsoft.Azure;
using Microsoft.Azure.Subscriptions;
using Newtonsoft.Json;

namespace APIManagmentConsole.Services.Implmentation
{
    public class SubscriptionsService : ISubscriptionsService
    {
        public async Task<List<Subscription>> GetSubscriptions(string tenantId, string token)
        {
            
            var subClient = new SubscriptionClient(new TokenCloudCredentials(tenantId, token));
            var list = await subClient.Subscriptions.ListAsync();
            if (list.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = JsonConvert.SerializeObject(list.Subscriptions);
                var res  = JsonConvert.DeserializeObject<List<Subscription>>(json);
            }

            return null;

        }
    }
}
