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

namespace APIManagmentConsole.ViewModel
{
    public class SubscriptionsViewModel : ViewModelBase
    {

        private readonly ISubscriptionsService subscriptionsService;

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
                GetSubscription();
            }
        }

        public ObservableCollection<Subscription> Subscriptions { get; set; }

        private object subscriptionsLock = new object();

        public SubscriptionsViewModel(ISubscriptionsService subscriptionsService)
        {
            this.subscriptionsService = subscriptionsService;
            Subscriptions = new ObservableCollection<Subscription>();
           
            BindingOperations.EnableCollectionSynchronization(Subscriptions, subscriptionsLock);
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

        private void GetSubscription()
        {
            MessageBox.Show(SelectedSubscription.SubscriptionId);
        }
    }
}
