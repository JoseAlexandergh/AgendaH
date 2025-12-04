using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using AgendaH.Model;

namespace AgendaH.Repository
{
    public class ContactoRepository : IRepository<Contacto>
    {
        private readonly string connectionString;

        public ContactoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        public void Save(Contacto contacto)
        {
            string query = @"INSERT INTO Contactos (PersonaId, Tipo, Valor) 
                             VALUES (@PersonaId, @Tipo, @Valor)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@PersonaId", contacto.PersonaId);
                    command.Parameters.AddWithValue("@Tipo", contacto.Tipo);
                    command.Parameters.AddWithValue("@Valor", contacto.Valor);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error SQL al guardar contacto. Detalles: {ex.Message}");
                }
            }
        }

        public List<Contacto> GetAll()
        {
            List<Contacto> listaContactos = new List<Contacto>();
            string query = @"
                SELECT 
                    C.Id, C.PersonaId, C.Tipo, C.Valor
                FROM Contactos C
                ORDER BY C.Id DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contacto c = new Contacto
                        {
                            Id = reader.GetInt32(0),
                            PersonaId = reader.GetInt32(1),
                            Tipo = reader.GetString(2),
                            Valor = reader.GetString(3)
                        };
                        listaContactos.Add(c);
                    }
                }
            }
            return listaContactos;
        }

        public void Update(Contacto contacto)
        {
            string query = @"UPDATE Contactos SET 
                                Tipo = @Tipo, 
                                Valor = @Valor
                            WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Tipo", contacto.Tipo);
                    command.Parameters.AddWithValue("@Valor", contacto.Valor);
                    command.Parameters.AddWithValue("@Id", contacto.Id);

                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No se encontró el contacto para actualizar.");
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error SQL al actualizar contacto. Detalles: {ex.Message}");
                }
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Contactos WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No se encontró el contacto para eliminar.");
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error SQL al eliminar contacto. Detalles: {ex.Message}");
                }
            }
        }

        public Contacto GetById(int id)
        {
            string query = "SELECT Id, PersonaId, Tipo, Valor FROM Contactos WHERE Id = @Id";
            Contacto contacto = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contacto = new Contacto
                        {
                            Id = reader.GetInt32(0),
                            PersonaId = reader.GetInt32(1),
                            Tipo = reader.GetString(2),
                            Valor = reader.GetString(3)
                        };
                    }
                }
            }
            return contacto;
        }
    }
}
