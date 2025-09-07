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
    internal class ScheduleDao
    {
        public void EntryDataTime(Schedule schedule)
        {
            using (var conn = DbConnection.Instance.GetConnection())
            {
                //Primero verificamos que el usuario exista
                string userCheck = "SELECT COUNT(*) FROM Users WHERE id = @id";
                int countUser = 0;
                using (var cmd = new SqlCommand(userCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@id", schedule.UserId);
                    countUser = (int)cmd.ExecuteScalar();
                }

                // Se verifica que exista el usuario
                if (countUser > 0)
                {
                    string query = "INSERT INTO Schedule (Entrytime, ExitTime, UserId) VALUES (@EntryTime, @ExitTime, @UserId)";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (schedule.EntryTime == default)
                        {
                            cmd.Parameters.AddWithValue("@EntryTime", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EntryTime", schedule.EntryTime);

                        }

                        if (schedule.ExitTime == default)
                        {
                            cmd.Parameters.AddWithValue("@ExitTime", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ExitTime", schedule.ExitTime);
                        }

                        cmd.Parameters.AddWithValue("@UserId", schedule.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
