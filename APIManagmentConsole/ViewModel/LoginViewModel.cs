using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using APIManagmentConsole.Services;
using APIManagmentConsole.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using APIManagmentConsole.Model;

namespace APIManagmentConsole
{
    public class LoginViewModel : ViewModelBase, IDisposable
    {
        private readonly ILoginService loginService;
        private string userName;
        private SecureString password;
        private RelayCommand loginCommand;
        private readonly MainViewModel parent;

        public LoginViewModel(ILoginService loginService, MainViewModel parent)
        {
            this.loginService = loginService;
            password = new SecureString();
            this.parent = parent;
        }

        private bool _IsAuthenticated;
        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set
            {
                if (value != _IsAuthenticated)
                {
                    _IsAuthenticated = value;
                    RaisePropertyChanged("IsAuthenticated");
                    RaisePropertyChanged("IsNotAuthenticated");
                }
            }
        }

        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        public SecureString Password
        {
            get
            {
                return password;
            }

            set
            {
                if (password == value)
                {
                    return;
                }

                password = value;
                RaisePropertyChanged("Password");
            }
        }
   
        public string Username
        {
            get
            {
                return userName;
            }

            set
            {
                if (userName == value)
                {
                    return;
                }

                userName = value;
                RaisePropertyChanged("Username");
            }
        }

    
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(async () =>
                {
                    try
                    {
                        IsAuthenticated = await loginService.Login(Username, Password);
                        parent.IsLoaded = IsAuthenticated;
                        Cleanup();
                    }
                    catch (Exception e)
                    {
                       MessageBox.Show(e.Message);
                    }
                  
                }));
            }
        }

        public override void Cleanup()
        {
            Username = string.Empty;
            Password.Clear();
            base.Cleanup();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                password.Dispose();
                password = null;
            }
        }
    }
}
