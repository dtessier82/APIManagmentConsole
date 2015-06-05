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
using APIManagmentConsole.Views;

namespace APIManagmentConsole.ViewModel
{
    public class APIListViewModel : ViewModelBase
    {
        private readonly IApiService apiService;
        private readonly IApiOperationService apiOperationService;
        private readonly MainViewModel parent;

        public ObservableCollection<ApiDefinition> ProductApis { get; set; }
        public ObservableCollection<Operation> ApiOperations { get; set; } 
        private RelayCommand getApiOperationsCommand;
        private RelayCommand exportApiCommand;
        private RelayCommand exportApiOperationCommand;
        
        public RelayCommand GetApiOperationsCommand
        {
            get {
                return getApiOperationsCommand ??
                       (getApiOperationsCommand = new RelayCommand(async () => await DoGetApiOperations(), CanGetApi));
            }
        }

        public RelayCommand ExportApiCommand
        {
            get
            {
                return exportApiCommand ??
                       (exportApiCommand = new RelayCommand(async () => await DoExportApi(), CanGetApi));
            }
        }

        public RelayCommand ExportApiOperationCommand
        {
            get
            {
                return exportApiOperationCommand ??
                       (exportApiOperationCommand = new RelayCommand(DoApiOperationExport, CanGetOperation));
            }
        }


        public APIListViewModel(IApiService apiService, IApiOperationService apiOperationService, MainViewModel parent)
        {
            this.apiService = apiService;
            this.apiOperationService = apiOperationService;
            this.parent = parent;
            ProductApis = new ObservableCollection<ApiDefinition>();
            ApiOperations = new ObservableCollection<Operation>();
        }

        private bool CanGetApi()
        {
            return SelectedApi != null;
        }

        private bool CanGetOperation()
        {
            return SelectedOperation != null;
        }

        private async Task DoExportApi()
        {
            var swagger =
               await
                   apiService.SwaggerExport(
                   App.GetApplicationContext().GetSubscriptionId(),
                   App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                   App.GetApplicationContext().GetServiceName(),
                   App.GetApplicationContext().GetResourceGroup(),
                   selectedApi.Id);

            MessageBox.Show(swagger);
        }

        private Operation selectedOperation;
        public Operation SelectedOperation
        {
            get { return selectedOperation; }
            set
            {
                selectedOperation = value;
                RaisePropertyChanged("SelectedOperation");
            }
        }

        private ApiDefinition selectedApi;
        public ApiDefinition SelectedApi
        {
            get { return selectedApi; }
            set
            {
                selectedApi = value;
                RaisePropertyChanged("SelectedApi");
                ApiOperations.Clear();
                RaisePropertyChanged("HasOperations");
            }
        }

        private Product product;
        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                RaisePropertyChanged("Product");
                if (product != null)
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetProductApis()));
                }
            }
        }

      
        public bool HasOperations
        {
            get { return !ApiOperations.IsNullOrEmpty(); }
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
                   product.Id);

           ProductApis.ClearAndAddAll(list);

        }

        private async Task DoGetApiOperations()
        {
            var list =
                await
                    apiService.ListApiOperationsAsync(
                    App.GetApplicationContext().GetSubscriptionId(),
                    App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                    App.GetApplicationContext().GetServiceName(),
                    App.GetApplicationContext().GetResourceGroup(),
                    selectedApi.Id);

            ApiOperations.ClearAndAddAll(list);
            RaisePropertyChanged("HasOperations");

        }

        private void DoApiOperationExport()
        {
            var jsonEditor = new APIJSONEditorViewModel(apiOperationService, apiService, 
                parent, ApiType.Operation, SelectedApi.Id,  SelectedOperation.Id);
            var win = new APIJsonEditView {DataContext = jsonEditor};
            win.ShowDialog();

        }
    }
}
