using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models.Enum;

namespace APIManagmentConsole.Models
{
    public class User
    {
        public User()
        {
            AssociatedGroups = new List<string>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public State State { get; set; }
        public List<string> AssociatedGroups { get; set; }

        public bool IsActive
        {
            get { return State == State.Active; }
        }

        public ApiManagementUser ApiManagementUser
        {
            get { return new ApiManagementUser(this); }
        }
    }
}
