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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        coffeeDBEntities db = new coffeeDBEntities("metadata=res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdl|res://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.136;initial catalog=coffeeDB;persist security info=True;user id=CoffeeUser;password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");



        public Login()
        {
            InitializeComponent();
        }

        

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            User validatedUser = new User();
            bool login = false;

            string currentUser = tbxUsrName.Text;
            string currentPassword = tbxPassword.Password;
            foreach (var user in db.Users)
            {
                if (user.email == currentUser && user.password == currentPassword)
                {
                     
                    login = true;
                    validatedUser = user;

                }
                else
                {                    
                    lblErrorMessage.Content = "Error : Username or Password incorrect";
                }
            }
            if (login)
            {
                CreateLogEntry("Login", "logged in", validatedUser.user_ID, validatedUser.email);
                 main_dashboard dashboard = new main_dashboard();
                 dashboard.user = validatedUser;
                 dashboard.ShowDialog();
                //this.Hide();
            }
            else
            {
                CreateLogEntry("Login", "User did not log in successfully.", 0, validatedUser.email);
            }

            
            // NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("main_dashboard.xaml", UriKind.RelativeOrAbsolute));

        }


        private void CreateLogEntry(string category, string description, int user_ID, string userName)
        {
            string comment = $"{description} user credentials = {userName}";
            Log log = new Log();
            log.user_ID = user_ID;
            log.Category = category;
            log.Description = comment;
            log.Date = DateTime.Now;
            SaveLog(log);
       }


        private void SaveLog(Log log)
        {
            db.Entry(log).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

           Environment.Exit(0);
        }

        
    }
}
