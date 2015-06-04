namespace APIManagmentConsole.Context
{
    public interface IApplicationContext
    {
        ISecurityContext GetSecurityContext();
        string GetClientId();
        string GetLoginUrl();
        string GetAPIUrl();
        string GetResourceGroup();
        string GetSubscriptionId();
        string GetServiceName();
        string GetProductId();

        void SetSecurityContext(ISecurityContext securityContext);
        void SetResourceGroup(string resourceGroup);
        void SetSubscriptionId(string subscriptionId);
        void SetProductId(string productId);
        void SetServiceName(string serviceName);


    }
}
