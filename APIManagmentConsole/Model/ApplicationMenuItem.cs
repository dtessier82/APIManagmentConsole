using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.Model
{
    public class ApplicationMenuItem
    {
        public string Header { get; set; }
        public List<ApplicationMenuItem> Children { get; set; }
        public RelayCommand Command { get; set; }
    }
}
