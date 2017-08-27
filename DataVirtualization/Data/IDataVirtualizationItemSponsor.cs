using System.Collections.Generic;

namespace Tomers.WPF.DataVirtualization.Data
{
    public interface IDataVirtualizationItemSponsor
    {
        void ExtendItems(IEnumerable<object> items);
        void DeflateItem(object item);
    }
}
