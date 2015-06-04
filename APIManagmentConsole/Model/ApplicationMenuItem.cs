using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;

namespace APIManagmentConsole.Model
{
    public class ApplicationMenuItem
    {
        public string Header { get; set; }
        public List<ApplicationMenuItem> Children { get; set; }
        public RelayCommand Command { get; set; }
    }
}
