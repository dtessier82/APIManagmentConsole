using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using APIManagmentConsole.Models;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows;
using Microsoft.Azure.Management.Resources.Models;

namespace APIManagmentConsole.ViewModel
{
    public class SideSelectionViewModel : ViewModelBase
    {

        private readonly ISubscriptionService subscriptionsService;
        private readonly IResourceGroupService resourceGroupService;


        private bool isSubscriptionSelected;

        public bool IsSubscriptionSelected
        {
            get { return isSubscriptionSelected; }
            set
            {
                isSubscriptionSelected = value;
                RaisePropertyChanged("IsSubscriptionSelected");
                if (IsSubscriptionSelected) {
                    GetResources();
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
                if (selectedSubscription != null)
                    IsSubscriptionSelected = true;
            }
        }

        public ObservableCollection<Subscription> Subscriptions { get; set; }
        public ObservableCollection<GenericResourceExtended> ResourceGroups { get; set; }

        public SideSelectionViewModel(ISubscriptionService subscriptionsService, IResourceGroupService resourceGroupService)
        {
            this.subscriptionsService = subscriptionsService;
            this.resourceGroupService = resourceGroupService;
            Subscriptions = new ObservableCollection<Subscription>();
            ResourceGroups = new ObservableCollection<GenericResourceExtended>();
        }

        public async Task GetSubscriptions()
        {
            var list =
                        await
                            subscriptionsService.GetSubscriptions(
                                App.GetApplicationContext().GetSecurityContext().GetTenantId(),
                                App.GetApplicationContext().GetSecurityContext().GetAccessToken());

            foreach (var item in list)
            {
                Subscriptions.Add(item);
            }
        }

        public void GetResources()
        {
            Task.Factory.StartNew(async () =>
            {
                var list =
                       await
                           resourceGroupService.ListAsync(
                               SelectedSubscription.SubscriptionId,
                               App.GetApplicationContext().GetSecurityContext().GetAccessToken());

                foreach (var item in list)
                {
                    this.ResourceGroups.Add(item);
                }
            });
           
        }

    }
}
