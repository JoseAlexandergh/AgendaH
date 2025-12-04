using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AgendaH.Model;

namespace AgendaH.Repository
{
    public class CitaRepository
    {
        private readonly string connectionString;

        public CitaRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        // --------------------
        // INSERTAR
        // --------------------
        public void Save(Cita cita)
        {
            string query = @"
                INSERT INTO Citas (PersonaID, Fecha, Motivo)
                VALUES (@PersonaID, @Fecha, @Motivo);";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonaID", cita.PersonaID);
                cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
                cmd.Parameters.AddWithValue("@Motivo", cita.Motivo ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // --------------------
        // ACTUALIZAR
        // --------------------
        public void Update(Cita cita)
        {
            string query = @"
                UPDATE Citas
                SET PersonaID = @PersonaID,
                    Fecha = @Fecha,
                    Motivo = @Motivo
                WHERE ID = @ID;";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonaID", cita.PersonaID);
                cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
                cmd.Parameters.AddWithValue("@Motivo", cita.Motivo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ID", cita.ID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // --------------------
        // OBTENER POR ID
        // --------------------
        public Cita GetById(int id)
        {
            Cita cita = null;

            string query = @"
                SELECT c.ID, c.PersonaID, c.Fecha, c.Motivo,
                       p.Nombre + ' ' + p.Apellido AS NombrePersona
                FROM Citas c
                INNER JOIN Personas p ON c.PersonaID = p.ID
                WHERE c.ID = @ID;";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cita = new Cita
                        {
                            ID = reader.GetInt32(0),
                            PersonaID = reader.GetInt32(1),
                            Fecha = reader.GetDateTime(2),
                            Motivo = reader.IsDBNull(3) ? null : reader.GetString(3),
                            NombrePersona = reader.IsDBNull(4) ? null : reader.GetString(4)
                        };
                    }
                }
            }

            return cita;
        }

        // --------------------
        // OBTENER TODAS
        // --------------------
        public List<Cita> GetAll()
        {
            var lista = new List<Cita>();

            string query = @"
                SELECT c.ID, c.PersonaID, c.Fecha, c.Motivo,
                       p.Nombre + ' ' + p.Apellido AS NombrePersona
                FROM Citas c
                INNER JOIN Personas p ON c.PersonaID = p.ID
                ORDER BY c.Fecha;";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cita
                        {
                            ID = reader.GetInt32(0),
                            PersonaID = reader.GetInt32(1),
                            Fecha = reader.GetDateTime(2),
                            Motivo = reader.IsDBNull(3) ? null : reader.GetString(3),
                            NombrePersona = reader.IsDBNull(4) ? null : reader.GetString(4)
                        });
                    }
                }
            }

            return lista;
        }

        // --------------------
        // BORRAR
        // --------------------
        public void Delete(int id)
        {
            string query = @"DELETE FROM Citas WHERE ID = @ID;";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
