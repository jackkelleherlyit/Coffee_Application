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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page
    {

        coffeeDBEntities db = new coffeeDBEntities("metadata=res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdl|res://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.139;initial catalog=coffeeDB;persist security info=True;user id=CoffeeUser;password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");

        List<User> users = new List<User>();
        List<Log> logs = new List<Log>();

        public Users()
        {
            InitializeComponent();
        }

        private void submenuAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            stkUserDetails.Visibility = Visibility.Visible;
            stkUserPanel.Visibility = Visibility.Visible;
        }

        private void submenuModifyUser_Click(object sender, RoutedEventArgs e)
        {
            stkUserDetails.Visibility = Visibility.Visible;
        }

        private void submenuDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            stkUserDetails.Visibility = Visibility.Visible;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            stkUserDetails.Visibility = Visibility.Collapsed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshUserList();
            lstLogList.ItemsSource = logs;
            

            foreach (var log in db.Logs)
            {
                logs.Add(log);
            }
          
         
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.email = tbxEmail.Text.Trim();
            user.first_name = tbxUserFirstName.Text.Trim();
            user.last_name = tbxUserLastName.Text.Trim();
            user.password = tbxPassword.Text.Trim();
            user.user_type = (Int16)cboUserType.SelectedIndex;           
            int saveSuccess = SaveUser(user);
            if(saveSuccess == 1)
            {
                MessageBox.Show("User successfully added");
                RefreshUserList();
                ClearUserDetails();
            }
            else
            {
                MessageBox.Show("Failed !  : Make sure you enter the correct details");
            }
        }
        public int SaveUser(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Added;
            int saveSuccess = db.SaveChanges();
            return saveSuccess;
        }

        private void RefreshUserList()
        {
            lstUserList.ItemsSource = users;
            users.Clear();
            foreach (var user in db.Users)
            {
                users.Add(user);
            }
        }

        private void ClearUserDetails()
        {
            tbxUserFirstName.Text = "";
            tbxemail.Text = "";
            tbxUserLastName.Text = "";
            tbxemail.Text = "";
            tbxPassword.Text = "";
            cboUserType.SelectedIndex = 0;
        }
        
    }
}
