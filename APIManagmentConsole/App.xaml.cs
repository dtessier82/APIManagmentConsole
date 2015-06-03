using System.Configuration;
using System.Windows;
using APIManagmentConsole.Context;
using GalaSoft.MvvmLight.Threading;
using APIManagmentConsole.Views;

namespace APIManagmentConsole
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IApplicationContext applicationContext;

        static App()
        {
            DispatcherHelper.Initialize();
            applicationContext = new ApplicationContext(ConfigurationManager.AppSettings["ClientId"],
                ConfigurationManager.AppSettings["LoginUrl"], ConfigurationManager.AppSettings["ResourceUrl"]);
        }

        public static IApplicationContext GetApplicationContext()
        {
            return applicationContext;
        }
    }
}
