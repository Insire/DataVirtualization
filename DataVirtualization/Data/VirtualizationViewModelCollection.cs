using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataVirtualization
{
    public class VirtualizationViewModelCollection : ObservableCollection<VirtualizationViewModel<EntryViewModel>>, IDataVirtualizationItemProvider
    {
        private readonly IDataProvider<EntryViewModel> _dataProvider;

        public VirtualizationViewModelCollection(IDataProvider<EntryViewModel> dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException();

            for (int i = 0; i < 1000; ++i)
                Add(new VirtualizationViewModel<EntryViewModel>(i, _dataProvider));
        }

        public void ExtendItems(IEnumerable<object> items)
        {
            var entries = items.Cast<VirtualizationViewModel<EntryViewModel>>();
            _dataProvider.Chunk(entries.Select(p => p.Id));

            foreach (var entry in items.Cast<VirtualizationViewModel<EntryViewModel>>())
                entry.Expand();
        }

        public void DeflateItem(object item)
        {
            var entry = item as VirtualizationViewModel<EntryViewModel>;
            entry?.Deflate();
        }
    }
}
