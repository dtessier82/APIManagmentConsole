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

namespace APIManagmentConsole
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginService loginService;
        private string username = string.Empty;
        private SecureString password;
        private RelayCommand loginCommand;

        public LoginViewModel(ILoginService loginService)
        {
            this.loginService = loginService;
        }
    
        /// <summary>
        /// The <see cref="Username"/> property name;
        /// </summary>
        public const string UsernamePropertyName = "Username";
        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                if (username == value)
                {
                    return;
                }

                username = value;
                RaisePropertyChanged(UsernamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Password"/> property name;
        /// </summary>
        public const string PasswordPropertyName = "Password";
        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SecureString Password
        {
            get
            {
                return password;
            }

            set
            {
                if (password != value)
                {
                    password = value;
                    RaisePropertyChanged(PasswordPropertyName);
                }
            }
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(async () =>
                {
                    var success = await loginService.Login(Username, Password);

                    if (success)
                    {
                        
                        var subs = new Subscriptions();
                        App.Current.MainWindow = subs;
                        subs.Show();
                    }


                }));
            }
        }
    }
}
