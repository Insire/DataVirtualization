using CefSharp;

namespace MagickFlow
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Browser_IsBrowserInitializedChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            Browser.LoadHtml("<html><head><title> aussagekräftiger Seitentitel </title><body><h1>Hello, Wörld ÄÜÖ!</h1></body></head></html>", "http://www.example.com/");
        }
    }
}
