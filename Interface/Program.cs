using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic;
using Entities;
using System.Windows.Forms;



namespace Interface
{
    class Program
    {
        static UserLogic userLogic = new UserLogic();
        static AnswardLogic answardLogic = new AnswardLogic();

        public static bool authorization;
        public static int ID;

        static void Main(string[] args)
        {
           
            authorization = false;

            Authorization();
           


            if (authorization)
            {
                Console.WriteLine("Выберите действие: \n 1.Посмотреть профиль \n 2.Посмотреть достижения \n 3.Поиск достижений");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(userLogic.GetByID(ID));
                        break;
                    case "2":
                        Console.WriteLine("Достижения:");
                        answardLogic.GetUserAnsward(ID);
                        break;
                    case "3":
                        Console.WriteLine("Поиск достижений:");
                        string Title = Console.ReadLine();
                        answardLogic.findAnsward(Title);
                        break;
                }
            }
        }
        public static void Authorization()
        {
            Console.WriteLine("Выберите действие: \n 1.Войти \n 2.Регистрация");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите логин:");
                    string Login = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string Password = Console.ReadLine();
                    userLogic.Authorization(Login, Password);
                    ID = userLogic.FindForLogin(Login);
                    authorization = true;
                    break;
                case "2":
                    Console.WriteLine("Введите имя:");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения:");
                    DateTime DateOfBrith = new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                    Console.WriteLine("Введите логин:");
                    string login = Console.ReadLine();
                    checkLogin(ref login);
                    Console.WriteLine("Введите пароль:");
                    string password = Console.ReadLine();

                    userLogic.Add(new User(Name, DateOfBrith, login, password));

                    authorization = true;
                    break;
            }
        }
        public static void checkLogin(ref string login)
        {
            if (!(userLogic.FindForLogin(login) < 1))
            {
                Console.WriteLine("Логин занят!");
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();
                checkLogin(ref login);
            }
        }
    }
}