using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models.Extensions
{
    internal static class ApiDefinitionExtensions
    {
        public static ApiDefinition ToBusinessModel(this ApiContract apiContract)
        {
            if (apiContract == null)
            {
                throw new ArgumentNullException("apiContract");
            }

            return new ApiDefinition
            {
                Name = apiContract.Name,
                Id = apiContract.Id,
                IdPath = apiContract.IdPath,
                Description = apiContract.Description,
                Path = apiContract.Path,
                Protocols = apiContract.Protocols.ToList(),
                ServiceUrl = apiContract.ServiceUrl,
                SubscriptionKeyParameter = apiContract.SubscriptionKeyParameterNames
            };
        }

        public static Operation ToBusinessModel(this OperationContract operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException("operation");
            }

            return new Operation
            {
                Name = operation.Name,
                Id = operation.OperationId,
                IdPath = operation.OperationIdPath,
                Description = operation.Description,
                ApiId = operation.ApiId,
                Method = operation.Method,
                Request = operation.Request,
                Responses = operation.Responses.ToList(),
                TemplateParameters = operation.TemplateParameters.ToList(),
                UrlTemplate = operation.UrlTemplate
                
            };
        }
    }
}
