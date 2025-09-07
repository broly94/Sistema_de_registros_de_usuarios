using Sistema_de_registros_de_usuarios.DAO;
using Sistema_de_registros_de_usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_registros_de_usuarios.Services
{
    internal class UserService
    {

        private readonly UserDao _userDao;

        public UserService(UserDao userDao)
        {
            this._userDao = userDao;
        }

        public void AddUserService(User user)
        {
            _userDao.AddUser(user);
        }

        public List<User> GetUsers()
        {
           return _userDao.GetUsers();
        }

        public int DeleteUser(string codeUser)
        {
            return _userDao.DeleteUser(codeUser);
        }
    }
}
