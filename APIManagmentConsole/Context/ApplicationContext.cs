namespace APIManagmentConsole.Context
{
    internal class ApplicationContext : IApplicationContext
    {
        private ISecurityContext securityContext;
        private string clientId;
        private string apiUrl;
        private string loginUrl;
        public string SubscriptionId { get; private set; }
        //public string ResourceGroup { get; private set; }

        public ApplicationContext(string clientId, string loginUrl, string apiUrl)
        {
            this.apiUrl = apiUrl;
            this.clientId = clientId;
            this.loginUrl = loginUrl;
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
    }
}
