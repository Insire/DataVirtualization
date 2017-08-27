using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Windows.Data;
using System.Windows.Threading;

namespace Tomers.WPF.DataVirtualization.Data
{
    public class DataVirtualizationCollectionView : ListCollectionView, ICacheItemRefreshAction
    {
        private readonly IDataVirtualizationItemSponsor _sponsor;
        private readonly HashSet<object> _deferredItems = new HashSet<object>();
        private readonly MemoryCache _cache;
        private readonly CacheItemPolicy _policy;

        private bool _isDeferred;

        public DataVirtualizationCollectionView(IList list) : base(list)
        {
            this._sponsor = list as IDataVirtualizationItemSponsor;
            _cache = new MemoryCache(nameof(DataVirtualizationCollectionView));
            _policy = new CacheItemPolicy()
            {
                SlidingExpiration = TimeSpan.FromSeconds(30),
                Priority = CacheItemPriority.Default,

            };
        }

        public override object GetItemAt(int index)
        {
            if (!_isDeferred)
            {
                _deferredItems.Clear();

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)LoadDeferredItems);

                _isDeferred = true;
            }

            var item = base.GetItemAt(index);
            if (!_deferredItems.Contains(item))
            {
                _deferredItems.Add(item);
            }

            return item;
        }

        public void Refresh(string removedKey, object expiredValue)
        {
            _sponsor.DeflateItem(expiredValue);
        }

        private void LoadDeferredItems()
        {
            var uniqueSet = new HashSet<object>();
            foreach (object item in _deferredItems)
            {
                var hashCode = item.GetHashCode();
                if (!_cache.Contains(hashCode.ToString()))
                {
                    uniqueSet.Add(item);
                }

                _cache.Add(new CacheItem(hashCode.ToString(), item), _policy);
            }

            _sponsor.ExtendItems(uniqueSet);
            _isDeferred = false;
        }
    }
}
