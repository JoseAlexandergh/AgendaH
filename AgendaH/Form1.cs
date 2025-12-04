using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace AgendaH
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPersonas();
            dataGridPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPersonas.ReadOnly = true;
        }

        private int ObtenerIDSeleccionado()
        {
            if (dataGridPersonas.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dataGridPersonas.CurrentRow.Cells["ID"].Value);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {


            int id = ObtenerIDSeleccionado();

            if (id <= 0)
            {
                MessageBox.Show("Seleccione un registro primero.");
                return;
            }

            if (MessageBox.Show("¿Seguro que deseas eliminar este registro?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            string query = "DELETE FROM Personas WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            CargarPersonas();
            MessageBox.Show("Registro eliminado.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridPersonas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para editar.");
                return;
            }

            txtBoxCedula.Text = dataGridPersonas.CurrentRow.Cells["Cedula"].Value.ToString();
            txtBoxNombre.Text = dataGridPersonas.CurrentRow.Cells["Nombre"].Value.ToString();
            txtBoxApellido.Text = dataGridPersonas.CurrentRow.Cells["Apellido"].Value.ToString();
            comboBoxSexo.Text = dataGridPersonas.CurrentRow.Cells["Sexo"].Value.ToString();
            dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(dataGridPersonas.CurrentRow.Cells["FechaNacimiento"].Value);
            txtBoxDireccion.Text = dataGridPersonas.CurrentRow.Cells["Direccion"].Value.ToString();
            txtBoxNotas.Text = dataGridPersonas.CurrentRow.Cells["Notas"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = ObtenerIDSeleccionado();

            if (id <= 0)
            {
                MessageBox.Show("Seleccione un registro para actualizar.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            string query = @"UPDATE Personas SET 
                        Cedula = @Cedula,
                        Nombre = @Nombre,
                        Apellido = @Apellido,
                        Sexo = @Sexo,
                        FechaNacimiento = @FechaNacimiento,
                        Direccion = @Direccion,
                        Notas = @Notas
                     WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Cedula", txtBoxCedula.Text.Trim());
                    command.Parameters.AddWithValue("@Nombre", txtBoxNombre.Text.Trim());
                    command.Parameters.AddWithValue("@Apellido", txtBoxApellido.Text.Trim());
                    command.Parameters.AddWithValue("@Sexo", comboBoxSexo.SelectedItem?.ToString() ?? string.Empty);
                    command.Parameters.AddWithValue("@FechaNacimiento", dateTimePickerFechaNacimiento.Value.Date);
                    command.Parameters.AddWithValue("@Direccion", txtBoxDireccion.Text);
                    command.Parameters.AddWithValue("@Notas", txtBoxNotas.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Registro actualizado correctamente.");
            CargarPersonas();
            LimpiarCampos();
        }

        private void CargarPersonas()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            string query = "SELECT * FROM Personas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridPersonas.DataSource = dt;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtBoxCedula.Text) || string.IsNullOrWhiteSpace(txtBoxNombre.Text))
            {
                MessageBox.Show("Cédula y Nombre son campos requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;


            string query = @"INSERT INTO Personas 
                             (Cedula, Nombre, Apellido, Sexo, FechaNacimiento, Direccion, Notas) 
                             VALUES 
                             (@Cedula, @Nombre, @Apellido, @Sexo, @FechaNacimiento, @Direccion, @Notas)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {

                        command.Parameters.AddWithValue("@Cedula", txtBoxCedula.Text.Trim());
                        command.Parameters.AddWithValue("@Nombre", txtBoxNombre.Text.Trim());
                        command.Parameters.AddWithValue("@Apellido", txtBoxApellido.Text.Trim());
                        command.Parameters.AddWithValue("@Sexo", comboBoxSexo.SelectedItem?.ToString() ?? string.Empty);
                        command.Parameters.AddWithValue("@FechaNacimiento", dateTimePickerFechaNacimiento.Value.Date);
                        command.Parameters.AddWithValue("@Direccion", txtBoxDireccion.Text);
                        command.Parameters.AddWithValue("@Notas", txtBoxNotas.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("¡Registro guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();

                            
                            CargarPersonas();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el registro. (0 filas afectadas)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        MessageBox.Show($"Error de Base de Datos (SQL):\n{sqlex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error inesperado al guardar:\n{ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            txtBoxCedula.Clear();
            txtBoxNombre.Clear();
            txtBoxApellido.Clear();
            txtBoxDireccion.Clear();
            txtBoxNotas.Clear();

            comboBoxSexo.SelectedIndex = -1;

            dateTimePickerFechaNacimiento.Value = DateTime.Now;
        }

        private void btnAbrirContactos_Click(object sender, EventArgs e)
        {
            FormContactos formContactos = new FormContactos(); // Crea la ventana
            formContactos.Show();                            // Muestra la ventana
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            FormCitas ventana = new FormCitas();
            ventana.Show();
        }

    }
}
