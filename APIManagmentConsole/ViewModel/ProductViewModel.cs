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

namespace APIManagmentConsole.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly IApiService apiService;


        public ProductViewModel(IApiService apiService)
        {
            this.apiService = apiService;
        }
        private string product;
        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                RaisePropertyChanged("Product");
                if (!string.IsNullOrEmpty(value))
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () => await GetProduct()));
                }
            }
        }

        private string productText;
        public string ProductText
        {
            get { return productText; }
            set
            {
                productText = value;
                RaisePropertyChanged("ProductText");
            }
        }

        private async Task GetProduct()
        {
           ProductText =
               await
                   apiService.SwaggerExport(
                   App.GetApplicationContext().GetSubscriptionId(),
                   App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                   App.GetApplicationContext().GetServiceName(),
                   App.GetApplicationContext().GetResourceGroup(),
                   product);

           // ProductText = JsonConvert.SerializeObject(api);

        }
    }
}
