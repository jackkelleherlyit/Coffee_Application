﻿using DBlibrary;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        CoffeeDBEntities db = new CoffeeDBEntities("metadata=res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdl|res://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.129;initial catalog=coffeeDB;user id=CoffeeUser;password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");
        



        public Login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            string currentUser = tbxUsrName.Text;
            string currentPassword = tbxPassword.Password;
            foreach (var user in db.Users.Where(t => t.email == currentUser && t.password == currentPassword));
            {
                MessageBox.Show("User authenticated");
            }


         NavigationService nav = NavigationService.GetNavigationService(this);
         nav.Navigate(new Uri("Customer_dashboard.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
