using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models.Extensions
{
    internal static class GroupExtensions
    {
        public static Group ToBusinessModel(this GroupContract group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }

            return new Group
            {
                Description = group.Description,
                Id = group.Id,
                IdPath = group.IdPath,
                ExternalId = group.ExternalId,
                SystemGroup = group.System,
                Name = group.Name,
                Type = group.Type
            };
        }
    }
}
