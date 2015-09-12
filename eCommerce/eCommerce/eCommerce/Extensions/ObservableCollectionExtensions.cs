using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace eCommerce.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void FillWith<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}