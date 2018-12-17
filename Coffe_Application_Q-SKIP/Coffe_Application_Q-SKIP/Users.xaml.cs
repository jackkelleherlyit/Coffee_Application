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
        
        appDBEntities db = new appDBEntities("metadata=res://*/Coffee_Application_model.csdl|res://*/Coffee_Application_model.ssdl|res://*/Coffee_Application_model.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.164.140;initial catalog=coffeeDB;persist security info=True;user id=CoffeeUser;password=password;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");

        List<User> users = new List<User>();
        List<Log> logs = new List<Log>();
        User selectedUser = new User();

        enum DBOperation
        {
            Add,
            Modify,
            Delete
        }

        DBOperation dbOperation = new DBOperation();

        public Users()
        {
            InitializeComponent();
        }

        private void submenuAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            //stkUserDetails.Visibility = Visibility.Visible;
            stkUserPanel.Visibility = Visibility.Visible;
        }

        private void submenuModifyUser_Click(object sender, RoutedEventArgs e)
        {
            stkUserPanel.Visibility = Visibility.Visible;
            dbOperation = DBOperation.Modify;
        }

        private void submenuDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            db.Users.RemoveRange(db.Users.Where(t => t.user_ID == selectedUser.user_ID));
            int saveSuccess = db.SaveChanges();
            if (saveSuccess == 1)
            {
                MessageBox.Show("User Deleted", "Save to database", MessageBoxButton.OK, MessageBoxImage.Information);
                RefreshUserList();
                ClearUserDetails();
                stkUserPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("An Error occurred", "Delete from database", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
            if (dbOperation == DBOperation.Add)
            {
                User user = new User();
                user.email = tbxEmail.Text.Trim();
                user.first_name = tbxUserFirstName.Text.Trim();
                user.last_name = tbxUserLastName.Text.Trim();
                user.password = tbxPassword.Text.Trim();
                user.user_type = (Int16)cboUserType.SelectedIndex;
                int saveSuccess = SaveUser(user);
                if (saveSuccess == 1)
                {
                    MessageBox.Show("User successfully added");
                    RefreshUserList();
                    ClearUserDetails();
                    stkUserPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Failed !  : Make sure you enter the correct details");
                }
            }
            if (dbOperation == DBOperation.Modify)
            {
                foreach (var user in db.Users.Where(t => t.user_ID == selectedUser.user_ID))
                {
                    user.first_name = tbxUserFirstName.Text.Trim();
                    user.last_name = tbxUserLastName.Text.Trim();
                    user.password = tbxPassword.Text.Trim();
                    user.email = tbxEmail.Text.Trim();
                    user.user_type = (Int16)cboUserType.SelectedIndex;
                }
                int saveSuccess = db.SaveChanges();
                if (saveSuccess == 1)
                {
                    MessageBox.Show("User modified successfully", "Save to database", MessageBoxButton.OK, MessageBoxImage.Information);
                    RefreshUserList();
                    ClearUserDetails();
                    stkUserPanel.Visibility = Visibility.Collapsed;
                }

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
            lstUserList.Items.Refresh();
        }

        private void ClearUserDetails()
        {
            tbxUserFirstName.Text = "";
            tbxemail.Text = "";
            tbxUserLastName.Text = "";
            tbxemail.Text = "";
            tbxPassword.Text = "";
            cboUserType.SelectedIndex = 0;
            tbxEmail.Text = "";
        }

        private void lstUserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstUserList.SelectedIndex > 0)
            {
                selectedUser = users.ElementAt(lstUserList.SelectedIndex);
                submenuModifyUser.IsEnabled = true;
                submenuDeleteUser.IsEnabled = true;
                if (dbOperation == DBOperation.Add)
                {
                    ClearUserDetails();
                }
                if (dbOperation == DBOperation.Modify)
                {
                    tbxUserFirstName.Text = selectedUser.first_name;
                    tbxUserLastName.Text = selectedUser.last_name;
                    tbxPassword.Text = selectedUser.password;
                    tbxEmail.Text = selectedUser.email;
                    cboUserType.SelectedIndex = selectedUser.user_type;
                }
            }
        }


        //Get the details of the content insde the comboBox
      /*  private void cboUserType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theComboBox = (ComboBox)sender;
            ComboBoxItem item = (ComboBoxItem)theComboBox.SelectedItem;
            string value = item.Content.ToString();
            MessageBox.Show("Content of ComboBox is" + value);
        }
        */
    }
}
