using Microsoft.Identity.Client;
using Sistema_de_registros_de_usuarios.DataBase;
using Sistema_de_registros_de_usuarios.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_registros_de_usuarios.DAO
{
    internal class UserDao
    {
        public void AddUser(User user)
        {
            using(var conn = DbConnection.Instance.GetConnection())
            {
                string query = "INSERT INTO Users (CodeUser, Name, Age) values (@CodeUser, @Name, @Age)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CodeUser", user.CodeUser);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.ExecuteNonQuery();
                }
            }            
        }

        public List<User> GetUsers()
        {

            List<User> users = new List<User>();
            
            using(var conn = DbConnection.Instance.GetConnection())
            {
                string query = "SELECT * FROM Users";
                using(var cmd = new SqlCommand(query, conn))
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            CodeUser = reader.GetString(1),
                            Name = reader.GetString(2),
                            Age = reader.GetInt32(3)
                        });
                    }
                }
            }

            return users;
        }

        public int DeleteUser(string codeUser)
        {
            using (var conn = DbConnection.Instance.GetConnection())
            {
                var query = "DELETE FROM Users WHERE CodeUser = @CodeUser";

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@CodeUser", "#" + codeUser);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
