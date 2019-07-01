using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBrith { get; set; }
     
        public string Login { get; set; }
        public string Password { get; set; }
       
        public User(string name, DateTime dateOfBrith, string login, string password)
        {
            Name = name;
            DateOfBrith = dateOfBrith;
            Login = login;
            Password = password;
        }
        public override string ToString()
        {
            return $"{ID}. Имя: {Name} Дата Рождения: {DateOfBrith.ToShortDateString()} ";
        }
    }
}
