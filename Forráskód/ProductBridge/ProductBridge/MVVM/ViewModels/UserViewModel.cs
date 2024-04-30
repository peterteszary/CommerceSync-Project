// UserViewModel.cs
using ProductBridge.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;

namespace ProductBridge.MVVM.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        private UserRepository userRepository;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private readonly UserRepository _userRepository;
        public UserViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            LoadUsers();
        }

        private void LoadUsers()
        {
            Users = new ObservableCollection<User>(_userRepository.GetAllUsersFromDatabase());
        }

        public void AddUser(User user)
        {
            _userRepository.InsertUser(user);
            LoadUsers();
        }

        public void DeleteUser(int userID)
        {
            _userRepository.DeleteUserFromDatabase(userID);
            LoadUsers();
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            LoadUsers();
        }
    }
}


