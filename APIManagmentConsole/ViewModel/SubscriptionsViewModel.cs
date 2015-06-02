using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace APIManagmentConsole.ViewModel
{
    public class SubscriptionsViewModel : ViewModelBase
    {

        private readonly ISubscriptionsService subscriptionsService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        private RelayCommand refreshCommand;

        public SubscriptionsViewModel(ISubscriptionsService subscriptionsService)
        {
            this.subscriptionsService = subscriptionsService;
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                return refreshCommand ?? (refreshCommand = new RelayCommand(async () =>
                {
                    var list =
                        await
                            subscriptionsService.GetSubscriptions(
                                App.GetApplicationContext().GetSecurityContext().GetTenantId(),
                                App.GetApplicationContext().GetSecurityContext().GetAccessToken());

                   

                }));
            }
        }
    }
}
