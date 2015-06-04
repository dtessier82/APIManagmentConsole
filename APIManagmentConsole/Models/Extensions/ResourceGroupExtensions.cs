using System;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace APIManagmentConsole.Models.Extensions
{
    internal static class ResourceGroupExtensions
    {
        public static ResourceGroup ToBusinessModel(this ResourceGroupExtended resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            return new ResourceGroup
            {
                Name = resource.Name,
                Id = resource.Id,
                Location = resource.Location,
            };
        }

        public static Resource ToBusinessModel(this GenericResourceExtended resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            return new Resource
            {
                Name = resource.Name,
                Id = resource.Id,
            };
        }
    }
}
