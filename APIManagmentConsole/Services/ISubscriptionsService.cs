using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models;

namespace APIManagmentConsole.Services
{
    public interface ISubscriptionsService
    {
        Task<List<Subscription>> GetSubscriptions(string tenantId, string accessToken);

    }
}
