using System.Threading.Tasks;
using APIManagmentConsole.Models;
using APIManagmentConsole.Services;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace APIManagmentConsole.ViewModel
{
    public class APIJSONEditorViewModel : ViewModelBase
    {
        private string jsonText;
        private readonly MainViewModel parent;
        private readonly IApiOperationService apiOperationService;
        private readonly IApiService apiService;
    

        public APIJSONEditorViewModel(IApiOperationService apiOperationService, IApiService apiService, 
            MainViewModel parent, ApiType type, string apiId, string aoId)
        {
            this.apiOperationService = apiOperationService;
            this.apiService = apiService;
            this.parent = parent;


            Task.Factory.StartNew(async () =>
            {
                await DoGetAsync(apiId, aoId, type);
            });

        }

        public string JsonText
        {
            get { return jsonText; }
            set
            {
                jsonText = value;
                RaisePropertyChanged("JsonText");
            }
        }


        public async Task DoGetAsync(string apiId, string aoId, ApiType type)
        {
            switch (type)
            {
                case ApiType.Api:
                    await GetApi(apiId);
                    break;
                    case ApiType.Operation:
                    await GetApiOperation(apiId, aoId);
                    break;
                    
            }
           
        }

        private async Task GetApiOperation(string apiId, string aoId)
        {
            var op = await apiOperationService.GetAsync(App.GetApplicationContext().GetSubscriptionId(),
               App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
               App.GetApplicationContext().GetServiceName(), App.GetApplicationContext().GetResourceGroup(),
               apiId, aoId);

            JsonText = JsonConvert.SerializeObject(op);
        }

        private async Task GetApi(string apiId)
        {
            var op = await apiService.GetAsync(App.GetApplicationContext().GetSubscriptionId(),
               App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
               App.GetApplicationContext().GetServiceName(), App.GetApplicationContext().GetResourceGroup(),
               apiId);

            JsonText = JsonConvert.SerializeObject(op);
        }
    }
}
