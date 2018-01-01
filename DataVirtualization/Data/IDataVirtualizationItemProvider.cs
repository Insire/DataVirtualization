using System.Collections.Generic;

namespace DataVirtualization
{
    public interface IDataVirtualizationItemProvider
    {
        void ExtendItems(IEnumerable<object> items);
        void DeflateItem(object item);
    }
}
