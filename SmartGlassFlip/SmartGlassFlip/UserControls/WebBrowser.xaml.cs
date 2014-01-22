using System.Windows.Controls;
using System.Windows.Input;

namespace SmartGlassFlip.UserControls
{
    /// <summary>
    /// Interaction logic for WebBrowser.xaml
    /// Code adapted from: http://www.wpf-tutorial.com/misc-controls/the-webbrowser-control/
    /// </summary>
    public partial class WebBrowser
    {
        public WebBrowser()
        {
            InitializeComponent();
            wbSample.Navigate("http://www.google.com");
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.Enter)
                wbSample.Navigate(txtUrl.Text);
        }

        private void wbSample_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            txtUrl.Text = e.Uri.OriginalString;
        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbSample != null) && (wbSample.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbSample.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbSample != null) && (wbSample.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbSample.GoForward();
        }

        private void GoToPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void GoToPage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbSample.Navigate(txtUrl.Text);
        }
    }
}
