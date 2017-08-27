using System.Collections.Generic;
using System.Collections.ObjectModel;

using Tomers.WPF.DataVirtualization.Data;

namespace Tomers.WPF.DataVirtualization
{
    public class HugeCollection : ObservableCollection<Entry>, IDataVirtualizationItemSponsor
    {
        public HugeCollection()
        {
            for (int i = 0; i < 1000; ++i)
            {
                var entry = new Entry(i);
                Add(entry);
            }
        }

        public void ExtendItems(IEnumerable<object> items)
        {
            foreach (Entry entry in items)
            {
                entry.IsExtended = true;
            }
        }

        public void DeflateItem(object item)
        {
            var entry = item as Entry;
            entry.IsExtended = false;
        }
    }
}
