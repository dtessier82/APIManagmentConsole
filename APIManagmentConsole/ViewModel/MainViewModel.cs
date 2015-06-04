using System.Collections.Generic;
using APIManagmentConsole.Model;
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
        public ProductViewModel ProductVM { get; private set; }

        private bool isLoaded;
        public bool IsLoaded
        {
            get
            {
                return isLoaded;
            }
            set
            {
                isLoaded = value;
                RaisePropertyChanged("IsLoaded");
                if (isLoaded)
                {
                    Load();
                }
            }
        }

        private bool showProductDetail;
        public bool ShowProductDetail
        {
            get
            {
                return showProductDetail;
            }
            set
            {
                showProductDetail = value;
                RaisePropertyChanged("ShowProductDetail");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ILoginService loginService,
            ISubscriptionService subscriptionService, 
            IResourceGroupService resourceGroupService,
            IProductService productService,
            IApiService apiService)
        {
            LoginVM = new LoginViewModel(loginService, this);
            SidePanelVM = new SideSelectionViewModel(subscriptionService, resourceGroupService, 
                productService, apiService, this);
            ProductVM = new ProductViewModel(apiService);

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

        public async void Load()
        {
            await SidePanelVM.GetSubscriptions();
        }

        private void DoLogout()
        {
            App.GetApplicationContext().SetSecurityContext(null);
            LoginVM.IsAuthenticated = false;
        }

        public void ShowApiDetail(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return;
            }

            ProductVM.Product = Id;
            ShowProductDetail = true;
        }
    }
}