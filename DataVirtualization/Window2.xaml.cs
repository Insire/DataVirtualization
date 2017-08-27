using System.Windows;
using System.Windows.Data;
using Tomers.WPF.DataVirtualization.Data;

namespace Tomers.WPF.DataVirtualization
{
    public partial class Window2
    {
        public Window2()
        {
            InitializeComponent();

            DataGridView.DataContext = new HugeCollection();
            ListViewView.DataContext = new HugeCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = ListViewView.TryFindResource("ListViewViewSource") as CollectionViewSource;
            if (view != null)
            {
                view.Filter += new FilterEventHandler(view_Filter);
            }
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            var entry = e.Item as Entry;
            e.Accepted = entry.Id % 2 == 0;
        }
    }
}
