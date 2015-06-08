/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:APIManagmentConsole.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System.Diagnostics.CodeAnalysis;
using APIManagmentConsole.Services;
using APIManagmentConsole.Services.Implmentation;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace APIManagmentConsole.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ILoginService, LoginService>();
            SimpleIoc.Default.Register<ISubscriptionService, SubscriptionService>();
            SimpleIoc.Default.Register<IResourceGroupService, ResourceGroupService>();
            SimpleIoc.Default.Register<IProductService, ProductService>();
            SimpleIoc.Default.Register<IApiService, ApiService>();
            SimpleIoc.Default.Register<IApiOperationService, ApiOperationService>();
            SimpleIoc.Default.Register<IUserService, UserService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SideSelectionViewModel>();
            SimpleIoc.Default.Register<APIListViewModel>();
            SimpleIoc.Default.Register<APIJSONEditorViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public APIJSONEditorViewModel ApiJsonEditor
        {
            get
            {
                return ServiceLocator.Current.GetInstance<APIJSONEditorViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}