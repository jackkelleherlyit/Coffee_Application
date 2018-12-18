using DBlibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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

        coffeeDBEntities db = new coffeeDBEntities("metadata=res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdl|res://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.145;initial catalog=coffeeDB;persist security info=True;user id=CoffeeUser;password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework&quot'");


        public Login()
        {
            InitializeComponent();
        }



        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            
            User validatedUser = new User();
            bool login = false;
            bool ValidateCredentials = false;

            string currentUser = tbxUsrName.Text;
            string currentPassword = tbxPassword.Password;
            ValidateCredentials = ValidateUserInput(currentUser, currentPassword);

            if (ValidateCredentials)
            {
                validatedUser = GetUserRecord(currentUser, currentPassword);
                if (validatedUser.user_ID > 0)
                {
                    CreateLogEntry("Login", "logged in", validatedUser.user_ID, validatedUser.email);
                    main_dashboard dashboard = new main_dashboard();
                    dashboard.user = validatedUser;
                    // dashboard.Owner = this;
                    //this.Hide();
                    dashboard.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Credentials do not exists", "User Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    //CreateLogEntry("Login", "User did not log in successfully.", 2, validatedUser.email);
                }

            }
            else
            {
                MessageBox.Show("Error with your username or password.", "User Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            // NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("main_dashboard.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Hide()
        {
            Environment.Exit(0);
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



        //validates user credentials against those in the SQL database

        private bool ValidateUserInput(string email, string password)   //email and password are entered by the user
        {
            //it's easier to set validated to false inside the checks than it is to validate each check

            bool validated = true;


            //email(username) can contain special chars and numbers but must be less than 30 chars
            if (email.Length == 0 || email.Length > 30)
            {
                validated = false;
            }


            // password must exist and can't be longer than 30 chars
            if (password.Length == 0 || password.Length > 30)
            {
                validated = false;
            }
            return validated;
        }


        //Gets the username and password passed to the method
        //from the Users table in the SQL database

        private User GetUserRecord(string email, string password)
        {
            User validatedUser = new User();
            try
            {
                foreach (var user in db.Users.Where(t => t.email == email && t.password == password))
                {
                    validatedUser = user;
                }
            }
            catch (EntityException )
            {
                MessageBox.Show("Problem connecting to the SQL server , Closing application" , "connectToDatabase", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            return validatedUser;
        }

    }

}




