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
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginService loginService;
        private UserLogin userLogin;
        private RelayCommand loginCommand;


        public LoginViewModel(ILoginService loginService)
        {
            this.loginService = loginService;
            userLogin = new UserLogin();
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
    
        /// <summary>
        /// The <see cref="UserLogin"/> property name;
        /// </summary>
        public const string UserLoginPropertyName = "UserLogin";
        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public UserLogin UserLogin
        {
            get
            {
                return userLogin;
            }

            set
            {
                if (userLogin == value)
                {
                    return;
                }

                userLogin = value;
                RaisePropertyChanged(UserLoginPropertyName);
            }
        }

    
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(async () =>
                {
                    IsAuthenticated = await loginService.Login(userLogin.Username, userLogin.Password);
                }));
            }
        }
    }
}
