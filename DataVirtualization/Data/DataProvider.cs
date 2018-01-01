using System.Collections.Generic;
using System.Diagnostics;

namespace DataVirtualization
{
    public class DataProvider : IDataProvider<EntryViewModel>
    {
        private readonly IDictionary<int, EntryViewModel> _cache;

        public DataProvider()
        {
            _cache = new Dictionary<int, EntryViewModel>();
        }

        public void Chunk(IEnumerable<int> Ids)
        {
            foreach (var id in Ids)
            {
                if (_cache.ContainsKey(id))
                    continue;

                _cache.Add(id, InternalGet(id));
            }
        }

        public EntryViewModel Get(int id)
        {
            return _cache[id];
        }

        private EntryViewModel InternalGet(int id)
        {
            Debug.WriteLine("Creating entry " + id);
            return new EntryViewModel(id);
        }
    }
}
