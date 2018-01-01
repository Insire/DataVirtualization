using System;
using System.ComponentModel;

namespace DataVirtualization
{
    public class VirtualizationViewModel<T> : INotifyPropertyChanged
        where T : class
    {
        private readonly IDataProvider<T> _dataProvider;

        private int _id;
        public int Id
        {
            get { return _id; }
            private set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged(nameof(Id));
                }
            }
        }

        private bool _isExtended = false;
        public bool IsExtended
        {
            get { return _isExtended; }
            private set
            {
                if (_isExtended != value)
                {
                    _isExtended = value;
                    NotifyPropertyChanged(nameof(IsExtended));
                }
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isExtended; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    NotifyPropertyChanged(nameof(IsBusy));
                }
            }
        }

        private T _viewModel;
        public T ViewModel
        {
            get { return _viewModel; }
            private set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    NotifyPropertyChanged(nameof(ViewModel));
                }
            }
        }

        public VirtualizationViewModel(int id, IDataProvider<T> dataProvider)
        {
            _id = id;

            _dataProvider = dataProvider ?? throw new ArgumentNullException();
        }

        public void Expand()
        {
            if (ViewModel != null)
                return;

            ViewModel = _dataProvider.Get(Id);
            IsExtended = true;
        }

        public void Deflate()
        {
            ViewModel = null; // enable GC
            IsExtended = false;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
