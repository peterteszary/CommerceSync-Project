using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProductBridge.MVVM.Model;
using ProductBridge.MVVM.ViewModels;
using ProductBridge.Repositories;
using WooCommerce.NET.WordPress.v2;

namespace ProductBridge.MVVM.View
{
    public partial class SearchUserView : Page

    {

        private List<User> users;

        public SearchUserView()
        {
            InitializeComponent();
            LoadUsersFromDatabase();
        }

        private void LoadUsersFromDatabase()
        {
            try
            {
                UserRepository userRepository = new UserRepository(App.Server, App.Database, App.Username, App.Password);
                users = userRepository.GetAllUsersFromDatabase().ToList();

                userListBox.ItemsSource = users; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a felhasználók betöltésekor: {ex.Message}");
            }
        }

        private void SearchUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Felhasználó keresése
                string userName = txtUserName.Text.Trim();
                string userId = txtUserID.Text.Trim();
                string userEmail = txtUserEmail.Text.Trim();
                string userRole = txtUserRole.Text.Trim();

                // Keresési feltételek
                var filteredUsers = users.Where(u =>
                    (string.IsNullOrEmpty(userName) || u.UserName.Contains(userName)) &&
                    (string.IsNullOrEmpty(userId) || u.UserId.ToString() == userId) &&
                    (string.IsNullOrEmpty(userEmail) || u.UserEmail.Contains(userEmail)) &&
                    (string.IsNullOrEmpty(userRole) || u.UserRole.Contains(userRole))
                ).ToList();

                // Szűrt felhasználók megjelenítése
                userListBox.ItemsSource = filteredUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a felhasználók keresésekor: {ex.Message}");
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiválasztott felhasználó törlése
                User selectedUser = (User)userListBox.SelectedItem;
                if (selectedUser != null)
                {
                    UserRepository userRepository = new UserRepository(App.Server, App.Database, App.Username, App.Password);
                    userRepository.DeleteUserFromDatabase(selectedUser.UserId);

                    // Termék eltávolítása a listából és ListBox frissítése
                    users.Remove(selectedUser);
                    userListBox.ItemsSource = null;
                    userListBox.ItemsSource = users;
                }
                else
                {
                    MessageBox.Show("Nincs kiválasztott felhasználó a törléshez.", "Nincs kiválasztva", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a felhasználó törlésekor: {ex.Message}");
            }
        }

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiválasztott felhasználó módosítása
                User selectedUser = (User)userListBox.SelectedItem;
                if (selectedUser != null)
                {
                    // Az új ablak megnyitása a felhasználó módosításához
                    EditUserWindow editUserWindow = new EditUserWindow(selectedUser);
                    editUserWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kérem válassza ki a módosítandó felhasználót.", "Nincs kiválasztva", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a felhasználó módosításakor: {ex.Message}");
            }
        }
    }
}
