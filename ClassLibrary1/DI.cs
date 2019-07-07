using BussinessLogic;
using BussinessLogic.Interface;
using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class DI
    {
        
        private static string conStr = ConfigurationManager.ConnectionStrings["sqlDao"].ConnectionString;
        private static IUserLogic userLogic;
        private static IAnswardLogic answardLogic;
        private static IUserDao userDao;
        private static IAnswardDAO answardDao;

        public static IUserLogic UserLogic => userLogic ?? new UserLogic(UserDao);

        public static IAnswardLogic AnswardLogic => answardLogic ?? new AnswardLogic(AnswardDao);

        public static IUserDao UserDao => userDao ?? new UserDAO(conStr);

        public static IAnswardDAO AnswardDao => answardDao ?? new AnswardDAO(conStr);
    }
}
