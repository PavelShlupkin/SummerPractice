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
        }





        public static void Authorization()
        {
            Console.Clear();
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
                    Check();
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

        public static void Check()
        {
            if (authorization)
            {
                Menu();
            }
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Выберите действие: \n 1.Посмотреть профиль \n 2.Посмотреть достижения \n 3.Выйти");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(userLogic.GetByID(ID));
                    Back();
                    break;
                case "2":
                    Answards();
                    break;
                case "3":
                    Authorization();
                    authorization = false;
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
        public static void Back()
        {
            Console.WriteLine("0.Назад");
            switch (Console.ReadLine())
            {
                case "0":
                    Menu();
                    break;
            }
        }
        public static void Answards()
        {
            Console.Clear();
            Console.WriteLine("Достижения \nВыберите достижение:");
            IEnumerable<Answard> list = answardLogic.GetUserAnsward(ID);
            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. Название: {list.ElementAt(i).Title}");
            }
            Console.WriteLine("0.Назад");
            Console.WriteLine("-1.Поиск");
            Console.WriteLine("-2.Добавить достижение");
            int j = int.Parse(Console.ReadLine());
            switch (j)
            {
                case 0:
                    Menu();
                    break;
                case -1:
                    FindAnsward();
                    break;
                case -2:
                    AddAnsward();
                    break;
            }
            if (j > 0) AnswardProfile(list.ElementAt(j - 1)); else Answards();
        }

        public static void FindAnsward()
        {
            Console.Clear();
            Console.WriteLine("Введите название: ");
            string name = Console.ReadLine();
            Console.WriteLine("Достижения \nВыберите достижение:");
            IEnumerable<Answard> list = answardLogic.findAnsward(ID, name);
            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. Название: {list.ElementAt(i).Title}");
            }
            int j = int.Parse(Console.ReadLine());
            AnswardProfile(list.ElementAt(j - 1));
        }

        public static void AddAnsward()
        {
            Console.Clear();
            Console.WriteLine("Введите название:");
            string title = Console.ReadLine();


            answardLogic.Add(new Answard(ID, title));
            Answards();
        }

        public static void AnswardProfile(Answard answard)
        {
            Console.Clear();
            Console.WriteLine(answard);
            Console.WriteLine("1.Изменить название \n2.Удалить  \n0.Назад");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Введите новое название: ");
                    string title = Console.ReadLine();
                    answardLogic.UpdateAnsward(answard.ID, title);
                    answard.Title = title;
                    AnswardProfile(answard);
                    break;

                case "2":
                    Console.WriteLine("Удалить достижение?");
                    switch (Console.ReadLine())
                    {
                        case "Да":
                            answardLogic.Remove(answard.ID);
                            Answards();
                            break;
                        case "Нет":
                            AnswardProfile(answard);
                            break;
                    }
                    break;
                case "0":
                    Answards();
                    break;
            }
        }
    }
}