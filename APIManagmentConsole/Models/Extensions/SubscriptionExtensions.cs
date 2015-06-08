using System;
using APIManagmentConsole.Models.Enum;
using AzureSubscription = Microsoft.Azure.Subscriptions.Models.Subscription;

namespace APIManagmentConsole.Models.Extensions
{
    internal static class SubscriptionExtensions
    {
        public static Subscription ToBusinessModel(this AzureSubscription subscription)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException("subscription");
            }

            return new Subscription
            {
                DisplayName = subscription.DisplayName,
                Id = subscription.Id,
                SubscriptionId = subscription.SubscriptionId,
                State = GetState(subscription)

            };
        }

        private static ProductState GetState(AzureSubscription subscription)
        {
            ProductState state;
            return ProductState.TryParse(subscription.State, out state) ? state : ProductState.NotPublished;
        }
    }
}
