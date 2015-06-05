using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManagmentConsole.ViewModel.Extensions
{
    internal static class ViewModelExtensions
    {
        public static void ClearAndAddAll<T>(this ObservableCollection<T> collection, List<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (collection == null)
            {
                collection = new ObservableCollection<T>();
            }

            collection.Clear();
            list.ForEach(item => collection.Add(item));
        }

        public static bool IsNullOrEmpty<T>(this ObservableCollection<T> collection)
        {

            if (collection == null)
                return true;

            return !collection.Any();
        }
    }
}
