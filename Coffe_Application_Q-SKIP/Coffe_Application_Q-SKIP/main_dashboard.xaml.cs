using DBlibrary;
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
    /// Interaction logic for main_dashboard.xaml
    /// </summary>
    public partial class main_dashboard : Page
    {
        public User user = new User();

        public main_dashboard()
        {
            InitializeComponent();
        }

        private void btnCoffee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Coffee.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnMyOrder_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Search.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));
        }

        

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Stock.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Users.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCustomer_Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Orders.xaml", UriKind.RelativeOrAbsolute));
        }

        private void checkUserAccess(User user)
        {
            if (user.user_type == "S")
            {
                btnCustomer_Order.Visibility = Visibility.Visible;
                btnStock.Visibility = Visibility.Visible;
            }
            else if(user.user_type == "A")
            {
                btnUsers.Visibility = Visibility.Visible;
                btnCustomer_Order.Visibility = Visibility.Visible;
                btnStock.Visibility = Visibility.Visible;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            checkUserAccess(user);
        }
    }
}
