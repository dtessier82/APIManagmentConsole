using System.Collections.Generic;
using System.Threading.Tasks;
using APIManagmentConsole.Models;

namespace APIManagmentConsole.Services
{
    public interface IProductService
    {
        Task<List<Product>> ListProductsAsync(string tenant, string accessToken, string resourceGroup, string serviceName);
        Task<Product> GetAsync(string tenant, string accessToken, string serviceName, string resourceGroup, string productId);
    }
}
