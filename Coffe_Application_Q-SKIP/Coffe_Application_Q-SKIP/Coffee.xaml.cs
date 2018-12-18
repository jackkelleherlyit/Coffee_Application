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
using DBlibrary;


namespace Coffe_Application_Q_SKIP
{

 
    /// <summary>
    /// Interaction logic for Coffee.xaml
    /// </summary>
    public partial class Coffee : Page
    {

        coffeeDBEntities db = new coffeeDBEntities("metadata=res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdl|res://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.145;initial catalog=coffeeDB;persist security info=True;user id=CoffeeUser;password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework&quot'"); List<Coffee> coffees = new List<Coffee>();
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
            coffee.coffeeType = (string)cboCoffee.SelectedItem;
            coffee.cupSize = (string)cboCoffeeSize.SelectedItem; 
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
