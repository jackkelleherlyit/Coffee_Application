
using DatabaseLibrary;
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
using System.Windows.Shapes;


namespace Coffe_Application_Q_SKIP
{
    /// <summary>
    /// Interaction logic for main_dashboard.xaml
    /// </summary>
    public partial class main_dashboard : Window
    {
        public User user = new User();

        public main_dashboard()
        {
            InitializeComponent();
        }

        private void btnCoffee_Click(object sender, RoutedEventArgs e)
        {
            Coffee coffee = new Coffee();
            frmMain_Dashboard.Navigate(coffee);
        }

        private void btnMyOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            frmMain_Dashboard.Navigate(search);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Exit exit = new Exit();
            Environment.Exit(0);
        }



        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock();
            frmMain_Dashboard.Navigate(stock);
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            frmMain_Dashboard.Navigate(users);
        }

        private void btnCustomer_Order_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            frmMain_Dashboard.Navigate(orders);
        }

        private void checkUserAccess(User user)
        {
            if (user.user_type == 2)
            {
                btnCustomer_Order.Visibility = Visibility.Visible;
                btnStock.Visibility = Visibility.Visible;
            }
            else if (user.user_type == 3)
            {
                btnUsers.Visibility = Visibility.Visible;
                btnCustomer_Order.Visibility = Visibility.Visible;
                btnStock.Visibility = Visibility.Visible;
            }
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkUserAccess(user);
        }
    }
}
