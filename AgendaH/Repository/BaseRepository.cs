using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaH.Repository
{
    public class BaseRepository
    {
        private readonly string connectionString =
            "Server=YOUR_SERVER;Database=AgendaPersonas;Trusted_Connection=True;";

        // ---------------------------
        // ExecuteNonQuery
        // ---------------------------
        protected void ExecuteNonQuery(string query, Action<SqlCommand> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    parameters?.Invoke(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ---------------------------
        // ExecuteReader
        // ---------------------------
        protected void ExecuteReader(string query, Action<SqlDataReader> readAction,
                                     Action<SqlCommand> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    parameters?.Invoke(cmd);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            readAction(reader);
                        }
                    }
                }
            }
        }
    }
}
