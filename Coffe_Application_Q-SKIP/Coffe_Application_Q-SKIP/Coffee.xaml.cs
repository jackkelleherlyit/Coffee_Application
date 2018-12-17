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
    /// Interaction logic for Coffee.xaml
    /// </summary>
    public partial class Coffee : Page
    {

        appDBEntities db = new appDBEntities("metadata=res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdl|res://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.140;initial catalog=coffeeDB;persist security info=True;user id=CoffeeUser;password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");

        List<Coffee> coffees = new List<Coffee>();
        List<Order> orders = new List<Order>();
        Coffee selectedCoffee = new Coffee();




        public Coffee()
        {
            InitializeComponent();
        }
        
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Orders.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Coffee coffee = new Coffee();
            coffee.cup_size = cboCoffee.SelectedItem;
            coffee.coffee_type = cboCoffeeSize.SelectedItem;
            int saveSuccess = SaveCoffee(coffee);
            if (saveSuccess == 1)
            {
                MessageBox.Show("Coffee Ordered Successfully");
              //  RefreshUserList();
                clearCoffeeDetails();
              //  stkUserPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Failed !  : We are out of stock");
            }
        }


        public int SaveCoffee(Coffee coffee)
        {
            db.Entry(coffee).State = System.Data.Entity.EntityState.Added;
            int saveSuccess = db.SaveChanges();
            return saveSuccess;
        }

        private void cboCoffeeSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboCoffee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCoffee.SelectedIndex > 0)
            {
                selectedCoffee = coffees.ElementAt(cboCoffee.SelectedIndex);
                clearCoffeeDetails();
            }
        }

        private void clearCoffeeDetails()
        {
            cboCoffee.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
     /*  
        private void RefreshTypeList()
        {

            coffees.Clear();
            foreach ( var coffeeType in db.Coffees)
            {
                coffees.Add(coffeeType);
            }
            cboCoffee.ItemsSource = coffees;
            cboCoffee.Items.Refresh();
        }

        private void RefreshSizeList()
        {
            sizeList.Clear();
            foreach (var coffeeSize in db.Coffees)
            {
                sizeList.Add(coffeeSize);
            }
            cboCoffeeSize.ItemsSource = sizeList;
            cboCoffeeSize.Items.Refresh();
        }
        */
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           // RefreshSizeList();
           // RefreshTypeList();
        }
    }
}
