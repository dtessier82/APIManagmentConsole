﻿using GalaSoft.MvvmLight;
using APIManagmentConsole.Model;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Controls;
using System.Collections.Generic;
using APIManagmentConsole.Model;
using APIManagmentConsole.Services;

namespace APIManagmentConsole.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public List<ApplicationMenuItem> Menu { get; set; }
        public RelayCommand LogoutCommand { get; set; }

        public LoginViewModel LoginVM { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ILoginService loginService)
        {
            LoginVM = new LoginViewModel(loginService);

            LogoutCommand = new RelayCommand(DoLogout);

            Menu = new List<ApplicationMenuItem>
            {
                new ApplicationMenuItem { Header = "Log off", Command = LogoutCommand },
                new ApplicationMenuItem { Header = "Other stuff", 
                    Children = new List<ApplicationMenuItem>
                    {
                        new ApplicationMenuItem { Header = "Load new control", Command = null },
                        new ApplicationMenuItem { Header = "Load control v2", Command = null },
                        new ApplicationMenuItem { Header = "Open new window", Command = null },
                    },
                },
            };
        }

        private void DoLogout()
        {
            App.GetApplicationContext().SetSecurityContext(null);

        }
    }
}