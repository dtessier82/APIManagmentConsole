using System.Collections.Generic;
using APIManagmentConsole.Model;
using APIManagmentConsole.Models;
using APIManagmentConsole.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

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
        public List<ApplicationMenuItem> Menu { get; private set; }
        public RelayCommand LogoutCommand { get; set; }
 
        public LoginViewModel LoginVM { get; private set; }

        public SideSelectionViewModel SidePanelVM { get; private set; }
        public APIListViewModel APIListVM { get; private set; }
        public UserListViewModel UserListVM { get; private set; }

        private bool isAuthenticated;
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set
            {
                if (value == isAuthenticated) 
                    return;

                isAuthenticated = value;
                RaisePropertyChanged("IsAuthenticated");
                if (isAuthenticated)
                {
                    Load();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ILoginService loginService,
            ISubscriptionService subscriptionService, 
            IResourceGroupService resourceGroupService,
            IProductService productService,
            IApiOperationService apiOperationService,
            IUserService userService,
            IApiService apiService)
        {
            LoginVM = new LoginViewModel(loginService, this);
            SidePanelVM = new SideSelectionViewModel(subscriptionService, resourceGroupService,  productService, apiService, this);
            APIListVM = new APIListViewModel(apiService, apiOperationService, this);
            UserListVM = new UserListViewModel(userService, this);
            LogoutCommand = new RelayCommand(DoLogout);

            Menu = new List<ApplicationMenuItem>
            {
                new ApplicationMenuItem { Header = "Log off", Command = LogoutCommand }
                //new ApplicationMenuItem { Header = "Other stuff", 
                //    Children = new List<ApplicationMenuItem>
                //    {
                //        new ApplicationMenuItem { Header = "Load new control", Command = null },
                //        new ApplicationMenuItem { Header = "Load control v2", Command = null },
                //        new ApplicationMenuItem { Header = "Open new window", Command = null },
                //    },
                //},
            };
        }

        public async void Load()
        {
            await SidePanelVM.GetSubscriptions();
        }

        private void DoLogout()
        {
            App.GetApplicationContext().SetSecurityContext(null);
            IsAuthenticated = false;
        }

        public void ShowApiDetail(Product product)
        {
            APIListVM.Product = product;
            APIListVM.ShowAPIList = true;
            UserListVM.ShowUserList = false;
        }

        public void ShowUserList(bool show)
        {
            APIListVM.ShowAPIList = !show;
            UserListVM.Show = show;
        }
    }
}