using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows.Threading;
using APIManagmentConsole.Services;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using APIManagmentConsole.Models;
using System.Collections.ObjectModel;
using APIManagmentConsole.ViewModel.Extensions;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace APIManagmentConsole.ViewModel
{
    public class APIListViewModel : ViewModelBase
    {
        private readonly IApiService apiService;

        public ObservableCollection<ApiDefinition> ProductApis { get; set; }
        private RelayCommand getApiCommand;

        public APIListViewModel(IApiService apiService)
        {
            this.apiService = apiService;
            ProductApis = new ObservableCollection<ApiDefinition>();
        }

        public RelayCommand GetApiCommand
        {
            get
            {
                return getApiCommand ?? (getApiCommand = new RelayCommand( () =>
                {
                    DoGetAPI();
                }));
            }
        }

        private void DoGetAPI()
        {
           MessageBox.Show("Selected ID:" + SelectedApi.Name);
        }

        private ApiDefinition selectedApi;
        public ApiDefinition SelectedApi
        {
            get { return selectedApi; }
            set
            {
                selectedApi = value;
                RaisePropertyChanged("SelectedApi");
            }
        }
        private string productId;
        public string ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                RaisePropertyChanged("ProductId");
                if (!string.IsNullOrEmpty(value))
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetProductApis()));
                }
            }
        }

        private async Task GetProductApis()
        {
           var list =
               await
                   apiService.ListProductApisAsync(
                   App.GetApplicationContext().GetSubscriptionId(),
                   App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                   App.GetApplicationContext().GetServiceName(),
                   App.GetApplicationContext().GetResourceGroup(),
                   productId);

           ProductApis.ClearAndAddAll(list);

        }
    }
}
