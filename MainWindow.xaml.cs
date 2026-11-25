using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pract8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.MainPage());
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.MainPage());
        }

        private void BucketList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.BucketList());
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Contacts());
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Catalog());
        }
    }
}