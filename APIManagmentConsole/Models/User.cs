using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Controls;
using APIManagmentConsole.Models.Enum;

namespace APIManagmentConsole.Models
{
    public class User : ApiManagementObject
    {
        public User()
        {
            AssociatedGroups = new List<Group>();
        }

        public string Id { get; set; }
        public string IdPath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public UserState State { get; set; }

        public string StateDescription
        {
            get { return State.ToString(); }
        }

        public DateTime RegistrationDate { get; set; }
        public List<Group> AssociatedGroups { get; set; }

        public bool IsActive
        {
            get { return State == UserState.Active; }
        }

        public string Username
        {
            get { return FirstName + " " + LastName; }
        }

        public string Groups
        {
            get
            {
                if (!AssociatedGroups.Any()) 
                    return null;

                var groups = string.Empty;
                AssociatedGroups.ForEach(group=>groups += @group.Name + " ");
                return groups;
            }
        }

        public bool IsPasswordProvided
        {
            get { return !string.IsNullOrEmpty(Password); }
        }
    }
}
