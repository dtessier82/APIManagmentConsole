using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models.Enum;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models.Extensions
{
    internal static class ProductExtensions
    {
        public static Product ToBusinessModel(this ProductContract resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            return new Product
            {
                Name = resource.Name,
                Id = resource.Id,
                Description = resource.Description,
                Terms = resource.Terms,
                IdPath = resource.IdPath,
                SubscriptionRequired = resource.SubscriptionRequired,
                SubscriptionsLimit = resource.SubscriptionsLimit,
                State = resource.State.Equals(ProductStateContract.Published) ? ProductState.Published : ProductState.NotPublished,
                ApprovalRequired = resource.ApprovalRequired
            };
        }
    }
}
