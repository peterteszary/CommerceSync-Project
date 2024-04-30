using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;

namespace ProductBridge.Controllers
{
    public class AddUserController
    {

        public void AddUser(User user)
        {
            var userRepository = new UserRepository(App.Server, App.Database, App.Username, App.Password);
            userRepository.InsertUser(user);
        }

    }
}
