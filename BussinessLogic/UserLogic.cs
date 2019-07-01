using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Interface;
using Entities;
using DAL;

namespace BussinessLogic
{
    public class UserLogic:IUserLogic
    {
        private UserDAO userDao = new UserDAO();
        public void Add(User value)
        {
            userDao.Add(value);
        }

        public IEnumerable<User> GetAll()
        {
            return userDao.GetAll();
        }

        public User GetByID(int ID)
        {
            return userDao.GetByID(ID);
        }

        public void Remove(int ID)
        {
            userDao.RemoveByID(ID);
        }

        public int FindForLogin(string Login)
        {
            return userDao.FindForLogin(Login);
        }

        public int Authorization(string Login, string Password)
        {
            return userDao.Authorization(Login, Password);
        }

        public void EditName(int ID, string Name)
        {
            userDao.EditName(ID, Name);
        }

        public void EditPassword(int ID, string Password)
        {
            userDao.EditPassword(ID, Password);
        }
    }
}
