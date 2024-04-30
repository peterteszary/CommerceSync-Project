using System;
using System.Windows;
using System.Windows.Controls;

namespace ProductBridge.MVVM.View
{
    public partial class GlobalMenu : UserControl
    {
        public GlobalMenu()
        {
            InitializeComponent();
        }

       

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Load NewProductWindow
            NewProductWindow NewProductWindow = new NewProductWindow();
            NewProductWindow.ShowDialog();
        }

        private void SearchProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Load SearchProductView page
            SearchProductView searchProductView = new SearchProductView();
            ((MainWindow)Window.GetWindow(this)).MainFrame.Content = searchProductView;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Load NewProductWindow
            NewUserWindow NewUserWindow = new NewUserWindow(App.Server, App.Database, App.Username, App.Password);
            NewUserWindow.ShowDialog();
        }


        private void SearchUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Load SearchUserView page
            SearchUserView searchUserView = new SearchUserView();
            ((MainWindow)Window.GetWindow(this)).MainFrame.Content = searchUserView;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Close application
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            // Implementáljuk az "Edit Profile" funkcionalitást
        }

        private void CredentialdButton_Click(object sender, RoutedEventArgs e)
        {
            // Load SearchProductView page
            CredentialsView credentialsView = new CredentialsView();
            ((MainWindow)Window.GetWindow(this)).MainFrame.Content = credentialsView;

        }

        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            // Load SearchProductView page
            SyncView SyncView = new SyncView();
            ((MainWindow)Window.GetWindow(this)).MainFrame.Content = SyncView;

        }
    }
}
