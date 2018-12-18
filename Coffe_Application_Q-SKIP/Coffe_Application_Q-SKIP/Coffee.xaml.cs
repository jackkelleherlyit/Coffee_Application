using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Coffe_Application_Q_SKIP
{
   

    /// <summary>
    /// Interaction logic for Coffee.xaml
    /// </summary>
    public partial class Coffee : Page
    {

        coffeeDBEntities db = new coffeeDBEntities("metadata = res://*/Q-SKIPmodel.csdl|res://*/Q-SKIPmodel.ssdl|res://*/Q-SKIPmodel.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.145;initial catalog=coffeeDB;persist security info=True;user id=CoffeeUser;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");


        List<Order> orders = new List<Order>();
        List<CoffeeOrder> coffeeOrders = new List<CoffeeOrder>();
        CoffeeOrder selectedCoffee = new CoffeeOrder();

        enum DBOperation
        {
            Add,           
        }

        DBOperation dbOperation = new DBOperation();


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
            
            CoffeeOrder coffee = new CoffeeOrder();
            coffee.coffeeType = cboCoffee.Text;
            coffee.cupSize = cboCoffeeSize.Text; 
            int saveSuccess = SaveCoffee(coffee);
            if (saveSuccess == 1)
            {
                MessageBox.Show("Coffee Ordered Successfully");
                clearCoffeeDetails();
            }
            else
            {
                MessageBox.Show("Failed !  : We are out of stock");
            }
        }


        public int SaveCoffee(CoffeeOrder coffee)
        {
            db.Entry(coffee).State = System.Data.Entity.EntityState.Added;
            int saveSuccess = db.SaveChanges();
            return saveSuccess;
        }

        private void cboCoffeeSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCoffeeSize.SelectedIndex > 0)
            {
                cboCoffeeSize.SelectedItem = selectedCoffee;
            }
            else
                MessageBox.Show("No value picked up");
        }

        private void cboCoffee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCoffee.SelectedIndex > 0)
            {
                cboCoffee.SelectedItem = selectedCoffee ;               
            }
            else
                MessageBox.Show("No value picked up");
        }

        private void clearCoffeeDetails()
        {
            cboCoffee.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            clearCoffeeDetails();
        }
       
      /*  private void RefreshTypeList()
        {

            coffees.Clear();
            foreach ( var  in db.CoffeeOrders)
            {
                coffees.Add(value);
            }
            cboCoffee.ItemsSource = coffees;
            cboCoffee.Items.Refresh();
        }

        private void RefreshSizeList()
        {
            sizeList.Clear();
            foreach (var coffeeSize in db.CoffeeOrders)
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
