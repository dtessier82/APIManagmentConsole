namespace APIManagmentConsole.Context
{
    internal class ApplicationSecurityContext : ISecurityContext
    {
        private string currentUser;
        private string accessToken;
        private string tenantId;

        public ApplicationSecurityContext(string currentUser, string accessToken, string tenantId)
        {
            this.accessToken = accessToken;
            this.currentUser = currentUser;
            this.tenantId = tenantId;
        }

        public string GetAccessToken()
        {
            return accessToken;
        }

        public string GetCurrentUser()
        {
           return currentUser;
        }

        public string GetTenantId()
        {
            return tenantId;
        }
     
    }
}
