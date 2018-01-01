using System.Collections.Generic;

namespace DataVirtualization
{
    public interface IDataProvider<T>
    {
        T Get(int id);
        void Chunk(IEnumerable<int> Ids);

        void ClearCache();

        void ClearCache(int id);
    }
}