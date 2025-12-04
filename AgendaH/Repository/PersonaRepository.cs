using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using AgendaH.Model;

namespace AgendaH.Repository
{
    // Implementa IRepository<Persona>
    public class PersonaRepository : IRepository<Persona>
    {
        private readonly string connectionString;

        public PersonaRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        // C de CRUD: SAVE (Insertar una nueva Persona)
        public void Save(Persona persona)
        {
            string query = @"INSERT INTO Personas (Cedula, Nombre, Apellido, Sexo, FechaNacimiento, Direccion, Notas) 
                             VALUES (@Cedula, @Nombre, @Apellido, @Sexo, @FechaNacimiento, @Direccion, @Notas)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Cedula", persona.Cedula);
                    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    command.Parameters.AddWithValue("@Sexo", persona.Sexo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                    command.Parameters.AddWithValue("@Direccion", persona.Direccion ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Notas", persona.Notas ?? (object)DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error al guardar Persona en la base de datos. Detalles: {ex.Message}");
                }
            }
        }

        // R de CRUD: GET ALL (Obtener todas las Personas)
        public List<Persona> GetAll()
        {
            List<Persona> listaPersonas = new List<Persona>();
            string query = "SELECT ID, Cedula, Nombre, Apellido, Sexo, FechaNacimiento, Direccion, Notas FROM Personas ORDER BY ID DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaPersonas.Add(new Persona
                        {
                            ID = reader.GetInt32(0),
                            Cedula = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            Apellido = reader.GetString(3),
                            Sexo = reader.IsDBNull(4) ? null : reader.GetString(4),
                            FechaNacimiento = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                            Direccion = reader.IsDBNull(6) ? null : reader.GetString(6),
                            Notas = reader.IsDBNull(7) ? null : reader.GetString(7),
                        });
                    }
                }
            }
            return listaPersonas;
        }

        // U y D de CRUD (Actualizar, Eliminar) y GetById se implementarán en la siguiente fase
        public void Update(Persona entity) { throw new NotImplementedException(); }
        public void Delete(int id) { throw new NotImplementedException(); }
        public Persona GetById(int id) { throw new NotImplementedException(); }
    }
}
