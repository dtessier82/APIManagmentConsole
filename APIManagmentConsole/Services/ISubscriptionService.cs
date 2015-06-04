using System.Collections.Generic;
using System.Threading.Tasks;
using APIManagmentConsole.Models;

namespace APIManagmentConsole.Services
{
    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetSubscriptions(string tenantId, string accessToken);
    }
}
