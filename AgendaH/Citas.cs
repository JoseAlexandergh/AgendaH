using AgendaH.Model;
using AgendaH.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgendaH
{
    public partial class FormCitas : Form
    {
        private readonly CitaRepository citaRepo = new CitaRepository();
        private readonly PersonaRepository personaRepo = new PersonaRepository();

        public FormCitas()
        {
            InitializeComponent();
        }

        private void FormCitas_Load(object sender, EventArgs e)
        {
            CargarPersonas();
            CargarCitas();
        }

        // -------------------------
        // CARGAR PERSONAS EN EL COMBO
        // -------------------------
        private void CargarPersonas()
        {
            var personas = personaRepo.GetAll();
            cbPersonas.DataSource = personas;
            cbPersonas.DisplayMember = "NombreCompleto";
            cbPersonas.ValueMember = "ID";
        }

        // -------------------------
        // CARGAR TABLA DE CITAS
        // -------------------------
        private void CargarCitas()
        {
            dgvCitas.DataSource = citaRepo.GetAll();
        }

        // -------------------------
        // GUARDAR / ACTUALIZAR
        // -------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cita cita = new Cita
                {
                    PersonaID = Convert.ToInt32(cbPersonas.SelectedValue),
                    Fecha = dtFecha.Value,
                    Motivo = txtMotivo.Text
                };

                if (string.IsNullOrEmpty(txtID.Text))
                {
                    // Nuevo
                    citaRepo.Save(cita);
                    MessageBox.Show("Cita registrada.");
                }
                else
                {
                    // Actualizar
                    cita.ID = int.Parse(txtID.Text);
                    citaRepo.Update(cita);
                    MessageBox.Show("Cita actualizada.");
                }

                LimpiarCampos();
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        // -------------------------
        // ELIMINAR
        // -------------------------
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Seleccione una cita primero.");
                return;
            }

            if (MessageBox.Show("¿Seguro que deseas eliminar esta cita?",
                                "Confirmar",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                citaRepo.Delete(int.Parse(txtID.Text));
                MessageBox.Show("Cita eliminada.");
                LimpiarCampos();
                CargarCitas();
            }
        }

        // -------------------------
        // LIMPIAR CAMPOS
        // -------------------------
        private void LimpiarCampos()
        {
            txtID.Clear();
            txtMotivo.Clear();
            cbPersonas.SelectedIndex = 0;
            dtFecha.Value = DateTime.Now;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // -------------------------
        // CUANDO SE HACE CLICK EN LA TABLA
        // -------------------------
        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCitas.Rows[e.RowIndex];

            txtID.Text = row.Cells["colID"].Value?.ToString();
            cbPersonas.SelectedValue = row.Cells["colPersonaID"].Value;
            dtFecha.Value = Convert.ToDateTime(row.Cells["colFecha"].Value);
            txtMotivo.Text = row.Cells["colMotivo"].Value?.ToString();
        }
    }
}
