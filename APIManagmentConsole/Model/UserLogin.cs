using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Model
{
    public class UserLogin
    {
        public string Username {get;set;}
        public SecureString Password {get;set;}

        //public string Error
        //{
        //    get { return ""; }
        //}

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string validationResult = null;
        //        switch (columnName)
        //        {
        //            case "Username":
        //                validationResult = ValidateUsername();
        //                break;
        //            case "Password":
        //                validationResult = ValidatePassword();
        //                break;
        //        }
        //        return validationResult;
        //    }
        //}

        //private string ValidateUsername()
        //{
        //    if (String.IsNullOrEmpty(this.Username))
        //        return "Username needs to be entered.";
        //    else if (this.Username.Length < 5)
        //        return "Product Name should have more than 5 letters.";
        //    else
        //        return String.Empty;
        //}

        //private string ValidatePassword()
        //{
        //    if (this.Password == null)
        //        return "Password needs to be entered.";
        //    else if (this.Password.Length < 5)
        //        return "Password should have more than 5 letters.";
        //    else
        //        return String.Empty;
        //}

    }
}
