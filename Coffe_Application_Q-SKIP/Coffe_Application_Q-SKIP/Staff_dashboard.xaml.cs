using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coffe_Application_Q_SKIP
{
    /// <summary>
    /// Interaction logic for Staff_dashboard.xaml
    /// </summary>
    public partial class Staff_dashboard : Page
    {
        public Staff_dashboard()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Search.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCoffee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Coffee.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Stock.xaml", UriKind.RelativeOrAbsolute));
        }

       

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btCustomerOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Orders.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnStock_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
