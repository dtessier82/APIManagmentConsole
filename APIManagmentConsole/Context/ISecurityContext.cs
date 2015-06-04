namespace APIManagmentConsole.Context
{
    public interface ISecurityContext
    {
        string GetAccessToken();
        string GetCurrentUser();
        string GetTenantId();
    }
}
