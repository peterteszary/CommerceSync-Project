using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;
using System.Windows;

namespace ProductBridge.MVVM.View.Controllers
{
    public class EditUserController
    {
        private readonly User _selectedUser;
        private readonly EditUserWindow _view;

        public EditUserController(User selectedUser, EditUserWindow view)
        {
            _selectedUser = selectedUser;
            _view = view;
        }

        public void LoadUserData()
        {
            if (_selectedUser != null) 
            {
                _view.txtUserName.Text = _selectedUser.UserName;
                _view.txtUserEmail.Text = _selectedUser.UserEmail;
                _view.txtUserPassword.Text = _selectedUser.UserPassword;
                _view.cmbUserRole.Text = _selectedUser.UserRole;
            }

        }


        // A mentési műveletet kezelő metódus
        public void SaveChanges()
        {
            if (_selectedUser != null)
            {
                _selectedUser.UserName = _view.txtUserName.Text;
                _selectedUser.UserEmail = _view.txtUserEmail.Text;
                _selectedUser.UserPassword = _view.txtUserPassword.Text;
                _selectedUser.UserRole = _view.cmbUserRole.Text;

                var userRepository = new UserRepository(App.Server, App.Database, App.Username, App.Password);
                userRepository.UpdateUser(_selectedUser);

                _view.Close();
            }
        }


        // A művelet megszakítását kezelő metódus
        public void Cancel()
        {
            _view.Close();
        }
    }
}
