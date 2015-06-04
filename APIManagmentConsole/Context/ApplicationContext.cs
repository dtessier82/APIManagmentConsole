namespace APIManagmentConsole.Context
{
    internal class ApplicationContext : IApplicationContext
    {
        private ISecurityContext securityContext;
        private string clientId;
        private string apiUrl;
        private string loginUrl;
        private string subscriptionId;
        private string resourceGroup;
        private string productId;
        private string serviceName;

        public ApplicationContext(string clientId, string loginUrl, string apiUrl)
        {
            this.apiUrl = apiUrl;
            this.clientId = clientId;
            this.loginUrl = loginUrl;
        }

        public void SetSubscriptionId(string subscriptionId)
        {
            this.subscriptionId = subscriptionId;
        }

        public string GetSubscriptionId()
        {
            return subscriptionId;
        }

        public void SetResourceGroup(string resourceGroup)
        {
            this.resourceGroup = resourceGroup;
        }

        public string GetResourceGroup()
        {
            return resourceGroup;
        }


        public ISecurityContext GetSecurityContext()
        {
            return securityContext;
        }

        public string GetClientId()
        {
            return clientId;
        }

        public string GetLoginUrl()
        {
            return loginUrl;
        }

        public string GetAPIUrl()
        {
           return apiUrl;
        }

        public void SetSecurityContext(ISecurityContext securityContext)
        {
            this.securityContext = securityContext;
        }

        public void SetProductId(string productId)
        {
            this.productId = productId;
        }

        public string GetProductId()
        {
            return productId;
        }

        public void SetServiceName(string serviceName)
        {
            this.serviceName = serviceName;
        }

        public string GetServiceName()
        {
            return serviceName;
        }
    }
}
