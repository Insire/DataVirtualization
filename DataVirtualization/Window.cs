using System.Windows;
using System.Windows.Data;

namespace DataVirtualization
{
    public partial class Window
    {
        public Window()
        {
            var dataProvider = new DataProvider();

            InitializeComponent();

            DataGridView.DataContext = new VirtualizationViewModelCollection(dataProvider);
            ListViewView.DataContext = new VirtualizationViewModelCollection(dataProvider);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewView.TryFindResource("ListViewViewSource") is CollectionViewSource view)
            {
                view.Filter += new FilterEventHandler(View_Filter);
            }
        }

        void View_Filter(object sender, FilterEventArgs e)
        {
            var entry = e.Item as VirtualizationViewModel<EntryViewModel>;
            e.Accepted = entry.ViewModel?.Id % 2 == 0;
        }
    }
}
