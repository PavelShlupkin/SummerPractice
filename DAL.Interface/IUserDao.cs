using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DAL.Interface
{
    public interface IUserDao
    {
        IEnumerable<User> GetAll();

        void Add(User value);

        void RemoveByID(int ID);

        User GetByID(int ID);

        int FindForLogin(string Login);

        int Authorization(string Login, string Password);

        void EditName(int ID, string Name);

        void EditPassword(int ID, string Password);
    }
}
