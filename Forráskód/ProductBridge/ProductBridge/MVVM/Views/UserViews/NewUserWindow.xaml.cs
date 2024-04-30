using ProductBridge.MVVM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace ProductBridge.MVVM.View
{
    public partial class NewUserWindow : Window
    {
        private readonly string connectionString;

        public NewUserWindow(string server, string database, string username, string password)
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void Add_User_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtUserEmail.Text) || string.IsNullOrWhiteSpace(txtUserPassword.Text) || cmbUserRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            User user = new User()
            {
                UserName = txtUserName.Text,
                UserEmail = txtUserEmail.Text,
                UserPassword = txtUserPassword.Text,
                UserRole = cmbUserRole.SelectedItem.ToString()
            };

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "INSERT INTO Users (UserName, UserEmail, UserPassword, UserRole) VALUES (@UserName, @UserEmail, @UserPassword, @UserRole)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", user.UserName);
                        command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                        command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                        command.Parameters.AddWithValue("@UserRole", user.UserRole);
                        command.ExecuteNonQuery();
                    }
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while adding user: {ex.Message}");
            }
        }

        private void Cancel_Add_User_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
