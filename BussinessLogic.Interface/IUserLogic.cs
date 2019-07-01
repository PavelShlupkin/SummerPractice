using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BussinessLogic.Interface
{
    public interface IUserLogic
    {
        IEnumerable<User> GetAll();

        void Add(User value);

        void Remove(int ID);

        User GetByID(int ID);

        int FindForLogin(string Login);

        int Authorization(string Login, string Password);

        void EditName(int ID, string Name);

        void EditPassword(int ID, string Password);
    }
}
