using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Entities;

namespace DAL
{
    public class UserDAO:IUserDao
    {
        private string _connectionString = @"Data Source=DESKTOP-VAAPLAB;Initial Catalog=task3;Integrated Security=True";

       
        public void Add(User value)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddUser";
                cmd.Parameters.AddWithValue(@"Name", value.Name);
                cmd.Parameters.AddWithValue(@"DateOfBrith", value.DateOfBrith);
                cmd.Parameters.AddWithValue(@"Login", value.Login);
                cmd.Parameters.AddWithValue(@"Password", value.Password);
                var id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ID",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllUser";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        DateOfBrith = (DateTime)reader["DateOfBrith"],
                        
                    });
                }
            }
            return users;
        }
        public User GetByID(int ID)
        {
            User user = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUserByID";
                cmd.Parameters.AddWithValue(@"ID", ID);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InitializeUser(ref user, reader);
                }
            }
            return user;
        }
        public void RemoveByID(int ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoveUser";
                cmd.Parameters.AddWithValue(@"ID", ID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int Authorization(string Login, string Password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "authorizationUser";
                cmd.Parameters.AddWithValue(@"Login", Login);
                cmd.Parameters.AddWithValue(@"Password", Password);
                connection.Open();

                return (int)cmd.ExecuteScalar();
            }
        }

        public void EditName(int ID, string Name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "editNameUser";
                cmd.Parameters.AddWithValue(@"ID", ID);
                cmd.Parameters.AddWithValue(@"Name", Name);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditPassword(int ID, string Password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "editPasswordUser";
                cmd.Parameters.AddWithValue(@"ID", ID);
                cmd.Parameters.AddWithValue(@"Password", Password);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int FindForLogin(string Login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "findForLogin";
                cmd.Parameters.AddWithValue(@"Login", Login);
                connection.Open();
                if (cmd.ExecuteScalar() != null) return (int)cmd.ExecuteScalar(); else return 0;
            }
        }

        private User InitializeUser(ref User user, SqlDataReader reader)
        {
            user = new User
            {
                ID = (int)reader["ID"],
                Name = (string)reader["Name"],
                DateOfBrith = (DateTime)reader["DateOfBrith"],
                Login = (string)reader["Login"],
                Password = (string)reader["Password"],
            };

            return user;
        }
    }
}
