using System.Windows;
using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;
using ProductBridge.MVVM.View.Controllers;

namespace ProductBridge.MVVM.View
{
    public partial class EditUserWindow : Window
    {
        private readonly EditUserController _controller;

        public EditUserWindow(User selectedUser)
        {
            InitializeComponent();
            _controller = new EditUserController(selectedUser, this);
            _controller.LoadUserData();
        }
        private void Update_User_Button_Click(object sender, RoutedEventArgs e)
        { 
            _controller.SaveChanges();
        }

        private void Cancel_Edit_User_Button_Click(object sender, RoutedEventArgs e)
        {
            _controller.Cancel();
        }
    }
}
