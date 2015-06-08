using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;

namespace APIManagmentConsole.ViewModel
{
    public abstract class BaseViewModel : ViewModelBase
    {
        private bool show;
        public bool Show
        {
            get { return show; }
            set
            {
                show = value;
                RaisePropertyChanged("Show");
                if (show)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(async () => await DoLoad()));
                }
            }
        }

        public abstract Task DoLoad();
    }
}
