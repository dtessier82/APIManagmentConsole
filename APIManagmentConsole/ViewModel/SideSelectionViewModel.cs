using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using APIManagmentConsole.Models;
using APIManagmentConsole.Services;
using APIManagmentConsole.ViewModel.Extensions;
using GalaSoft.MvvmLight;

namespace APIManagmentConsole.ViewModel
{
    public class SideSelectionViewModel : ViewModelBase
    {

        private readonly ISubscriptionService subscriptionsService;
        private readonly IResourceGroupService resourceGroupService;
        private readonly IProductService productService;
        private readonly IApiService apiService;

        private readonly MainViewModel parent;

        private bool isSubscriptionSelected;
        public bool IsSubscriptionSelected
        {
            get { return isSubscriptionSelected; }
            set
            {
                isSubscriptionSelected = value;
                RaisePropertyChanged("IsSubscriptionSelected");
                if (IsSubscriptionSelected) {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetResourceGroups()));
                }

               
            }
        }

        private Subscription selectedSubscription;
        public Subscription SelectedSubscription
        {
            get { return selectedSubscription; }
            set
            {
                if(value == selectedSubscription)
                    return;

                selectedSubscription = value;
                RaisePropertyChanged("SelectedSubscription");
                if (selectedSubscription == null) return;

                IsSubscriptionSelected = true;
                App.GetApplicationContext().SetSubscriptionId(selectedSubscription.SubscriptionId);
            }
        }

        private bool isResourceGroupSelected;
        public bool IsResourceGroupSelected
        {
            get { return isResourceGroupSelected; }
            set
            {
                isResourceGroupSelected = value;
                RaisePropertyChanged("IsResourceGroupSelected");
                if (IsSubscriptionSelected)
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetResources()));
                }


            }
        }

        private ResourceGroup selectedResourceGroup;
        public ResourceGroup SelectedResourceGroup
        {
            get { return selectedResourceGroup; }
            set
            {
                if (value == selectedResourceGroup)
                    return;

                selectedResourceGroup = value;
                RaisePropertyChanged("SelectedResourceGroup");
                if (selectedResourceGroup == null) 
                    return;

                App.GetApplicationContext().SetResourceGroup(selectedResourceGroup.Name);
                IsResourceGroupSelected = true;
            }
        }


        private bool isResourceSelected;
        public bool IsResourceSelected
        {
            get { return isResourceSelected; }
            set
            {
                isResourceSelected = value;
                RaisePropertyChanged("IsResourceSelected");
                if (isResourceSelected)
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetProducts()));
                }


            }
        }

        private Resource selectedResource;
        public Resource SelectedResource
        {
            get { return selectedResource; }
            set
            {
                if (value == selectedResource)
                    return;

                selectedResource = value;
                RaisePropertyChanged("SelectedResource");
                if (selectedResourceGroup == null) return;
                App.GetApplicationContext().SetServiceName(selectedResource.Name);
                IsResourceSelected = true;
            }
        }

        private bool isProductSelected;
        public bool IsProductSelected
        {
            get { return isProductSelected; }
            set
            {
                isProductSelected = value;
                RaisePropertyChanged("IsProductSelected");
                if (isProductSelected)
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetProductApis()));
                }


            }
        }


        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (value == selectedProduct)
                    return;

                selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
                if (selectedProduct == null) return;
                App.GetApplicationContext().SetProductId(selectedProduct.Id);
                IsProductSelected = true;
            }
        }

        private bool isApiSelected;
        public bool IsApiSelected
        {
            get { return isApiSelected; }
            set
            {
                isApiSelected = value;
                RaisePropertyChanged("IsApiSelected");
                if (isApiSelected)
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetApiOperations()));
                }


            }
        }

        private ApiDefinition selectedApi;
        public ApiDefinition SelectedApi
        {
            get { return selectedApi; }
            set
            {
                if (value == selectedApi)
                    return;

                selectedApi = value;
                RaisePropertyChanged("SelectedApi");
                if (selectedApi == null) return;
                IsApiSelected = true;
               // parent.ShowApiDetail(selectedApi.Id);
            }
        }

        private Operation selectedApiOperation;
        public Operation SelectedApiOperation
        {
            get { return selectedApiOperation; }
            set
            {
                if (value == selectedApiOperation)
                    return;

                selectedApiOperation = value;
                RaisePropertyChanged("SelectedApi");
                if (selectedApiOperation == null) return;
                parent.ShowApiDetail(selectedApiOperation.ApiId);
            }
        }

        public ObservableCollection<Subscription> Subscriptions { get; set; }
        public ObservableCollection<ResourceGroup> ResourceGroups { get; set; }
        public ObservableCollection<Resource> Resources { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<ApiDefinition> Apis { get; set; }
        public ObservableCollection<Operation> ApiOperations { get; set; } 

        public SideSelectionViewModel(ISubscriptionService subscriptionsService, 
            IResourceGroupService resourceGroupService, IProductService productService, 
            IApiService apiService, MainViewModel parent)
        {
            this.subscriptionsService = subscriptionsService;
            this.resourceGroupService = resourceGroupService;
            this.productService = productService;
            this.apiService = apiService;
            this.parent = parent;

            Subscriptions = new ObservableCollection<Subscription>();
            ResourceGroups = new ObservableCollection<ResourceGroup>();
            Resources = new ObservableCollection<Resource>();
            Products = new ObservableCollection<Product>();
            Apis = new ObservableCollection<ApiDefinition>();
            ApiOperations = new ObservableCollection<Operation>();
        }

        public async Task GetSubscriptions()
        {
            var list =
                        await
                            subscriptionsService.GetSubscriptions(
                                App.GetApplicationContext().GetSecurityContext().GetTenantId(),
                                App.GetApplicationContext().GetSecurityContext().GetAccessToken());

            Subscriptions.ClearAndAddAll(list);
     
        }

        public async Task GetResourceGroups()
        {

            var list =
                await
                    resourceGroupService.ListAsync(SelectedSubscription.SubscriptionId,
                        App.GetApplicationContext().GetSecurityContext().GetAccessToken());

            ResourceGroups.ClearAndAddAll(list);

        }

        public async Task GetResources()
        {

            var list =
                await
                    resourceGroupService.ListApiManagementResourcesAsync(SelectedSubscription.SubscriptionId,
                        App.GetApplicationContext().GetSecurityContext().GetAccessToken(), SelectedResourceGroup.Name);

            Resources.ClearAndAddAll(list);

        }


        public async Task GetProducts()
        {
            var list =
                await
                    productService.ListProductsAsync(
                     SelectedSubscription.SubscriptionId,
                    App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                        SelectedResource.Name, SelectedResourceGroup.Name);

           Products.ClearAndAddAll(list);
        }

        public async Task GetProductApis()
        {
            var list =
                await
                    apiService.ListProductApisAsync(
                     SelectedSubscription.SubscriptionId,
                    App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                        SelectedResource.Name, SelectedResourceGroup.Name, SelectedProduct.Id);

            Apis.ClearAndAddAll(list);
        }

        public async Task GetApiOperations()
        {
            var list =
                await
                    apiService.ListApiOperationsAsync(
                     SelectedSubscription.SubscriptionId,
                    App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                        SelectedResource.Name, SelectedResourceGroup.Name, SelectedApi.Id);

            ApiOperations.ClearAndAddAll(list);
        }
    }
}
