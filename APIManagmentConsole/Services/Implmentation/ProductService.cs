using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models;
using APIManagmentConsole.Models.Extensions;
using Microsoft.Azure;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;
using Newtonsoft.Json;

namespace APIManagmentConsole.Services.Implmentation
{
    public class ProductService : IProductService
    {
        public async Task<List<Product>> ListProductsAsync(string tenant, string accessToken, string serviceName, string resourceGroup)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenant, accessToken));
            var products = await apimClient.Products.ListAsync(resourceGroup, serviceName, null);
            return products.StatusCode.Equals(HttpStatusCode.OK)
                ? products.Result.Values.ToList().Select(product => product.ToBusinessModel()).ToList()
                : new List<Product>();
        }

        public async Task<Product> GetAsync(string tenant, string accessToken, string serviceName, string resourceGroup, string productId)
        {
            var apimClient = new ApiManagementClient(new TokenCloudCredentials(tenant, accessToken));
            var product = await apimClient.Products.GetAsync(resourceGroup, serviceName, productId);
            return product.StatusCode.Equals(HttpStatusCode.OK)
                ? product.Value.ToBusinessModel()
                : null;
        }
    }
}
