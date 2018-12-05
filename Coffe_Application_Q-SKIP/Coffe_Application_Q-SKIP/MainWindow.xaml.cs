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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        coffeeDBEntities db = new coffeeDBEntities("metadata = res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdlres://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source = 192.168.1.130; initial catalog = coffeeDB; userid = CoffeeUser; password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
