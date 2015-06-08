using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models.Enum;
using Microsoft.Azure.Management.ApiManagement.SmapiModels;

namespace APIManagmentConsole.Models.Extensions
{
    internal static class UserExtensions
    {
        public static User ToBusinessModel(this UserContract resource, string Etag)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            return new User
            {
                ETag = Etag,
                FirstName = resource.FirstName,
                Id = resource.Id,
                State = resource.State.Equals(UserStateContract.Active) ? UserState.Active : UserState.Blocked,
                LastName = resource.LastName,
                Email = resource.Email,
                IdPath = resource.IdPath,
                RegistrationDate = resource.RegistrationDate,
                Note = resource.Note
            };
        }

        public static UserUpdateParameters ToUpdateModel(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return new UserUpdateParameters
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Note = user.Note,
                State = user.State.Equals(UserState.Active) ? UserStateContract.Active : UserStateContract.Blocked
            };

        }
    }
}
