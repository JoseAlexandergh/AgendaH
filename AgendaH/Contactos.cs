using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AgendaH.Model;
using AgendaH.Repository;

namespace AgendaH
{
    public partial class FormContactos : Form
    {
        private readonly ContactoRepository contactoRepository;
        private readonly PersonaRepository personaRepository;
        private List<Persona> listaPersonas;
        private Contacto contactoSeleccionado;

        public FormContactos()
        {
            InitializeComponent();
            contactoRepository = new ContactoRepository();
            personaRepository = new PersonaRepository();
            contactoSeleccionado = null;
        }

        private void Load_Contactos(object sender, EventArgs e)
        {
            try
            {
                CargarTiposContacto();
                CargarPersonasEnComboBox();
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar: " + ex.Message);
            }
        }

        // -----------------------------------------------------------
        //                  CARGA INICIAL
        // -----------------------------------------------------------

        private void CargarTiposContacto()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Email");
            cmbTipo.Items.Add("Móvil");
            cmbTipo.Items.Add("Teléfono Fijo");
            cmbTipo.Items.Add("WhatsApp");
            cmbTipo.Items.Add("Red Social");
            cmbTipo.SelectedIndex = 0;
        }

        private void CargarPersonasEnComboBox()
        {
            listaPersonas = personaRepository.GetAll();
            cmbPersonaID.DataSource = listaPersonas;
            cmbPersonaID.DisplayMember = "NombreCompleto";
            cmbPersonaID.ValueMember = "ID";

            if (listaPersonas.Any())
                cmbPersonaID.SelectedIndex = 0;
        }

        private void CargarContactos()
        {
            var contactos = contactoRepository.GetAll();
            dataGridContactos.DataSource = ConvertListToDataTable(contactos);

            if (dataGridContactos.Columns.Contains("PersonaId"))
                dataGridContactos.Columns["PersonaId"].Visible = false;
        }

        // -----------------------------------------------------------
        //                        GUARDAR
        // -----------------------------------------------------------

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (contactoSeleccionado == null)
                    GuardarNuevo();
                else
                    ActualizarExistente();

                Limpiar();
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void GuardarNuevo()
        {
            if (cmbPersonaID.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una persona.");
                return;
            }

            Contacto nuevo = new Contacto
            {
                PersonaId = (int)cmbPersonaID.SelectedValue,
                Tipo = cmbTipo.Text,
                Valor = txtValor.Text
            };

            contactoRepository.Save(nuevo);
            MessageBox.Show("Guardado.");
        }

        // -----------------------------------------------------------
        //                       ACTUALIZAR
        // -----------------------------------------------------------

        private void ActualizarExistente()
        {
            contactoSeleccionado.PersonaId = (int)cmbPersonaID.SelectedValue;
            contactoSeleccionado.Tipo = cmbTipo.Text;
            contactoSeleccionado.Valor = txtValor.Text;

            contactoRepository.Update(contactoSeleccionado);
            MessageBox.Show("Modificado.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (contactoSeleccionado == null)
            {
                MessageBox.Show("Elija una fila.");
                return;
            }

            ActualizarExistente();
            Limpiar();
            CargarContactos();
        }

        // -----------------------------------------------------------
        //                        BORRAR
        // -----------------------------------------------------------

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (contactoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un contacto.");
                return;
            }

            if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                contactoRepository.Delete(contactoSeleccionado.Id);
                MessageBox.Show("Eliminado.");
                Limpiar();
                CargarContactos();
            }
        }

        // -----------------------------------------------------------
        //                     SELECCIÓN GRID
        // -----------------------------------------------------------

        private void dataGridContactos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridContactos.SelectedRows.Count == 0)
                return;

            var row = dataGridContactos.SelectedRows[0];

            // 1. Validar que la columna exista
            if (!row.Cells.Contains(row.Cells["Id"]))
                return;

            // 2. Validar que no esté vacío
            if (row.Cells["Id"].Value == null || row.Cells["Id"].Value == DBNull.Value)
                return;

            // 3. Convertir correctamente (sin cast directo peligroso)
            int id;

            if (!int.TryParse(row.Cells["Id"].Value.ToString(), out id))
                return;

            // 4. Buscar el contacto real
            contactoSeleccionado = contactoRepository.GetById(id);

            if (contactoSeleccionado == null)
                return;

            // 5. Cargar datos al formulario
            cmbPersonaID.SelectedValue = contactoSeleccionado.PersonaId;
            cmbTipo.Text = contactoSeleccionado.Tipo;
            txtValor.Text = contactoSeleccionado.Valor;

            btnGuardar.Text = "Actualizar";
        }


        // -----------------------------------------------------------
        //                         EXTRA
        // -----------------------------------------------------------

        private void Limpiar()
        {
            if (listaPersonas.Any())
                cmbPersonaID.SelectedIndex = 0;

            cmbTipo.SelectedIndex = 0;
            txtValor.Text = "";

            contactoSeleccionado = null;
            btnGuardar.Text = "Guardar";
            dataGridContactos.ClearSelection();
        }

        private DataTable ConvertListToDataTable<T>(List<T> items)
        {
            DataTable tabla = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties();

            foreach (var p in props)
            {
                var tipo = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                if (tipo.IsPrimitive || tipo == typeof(string) || tipo == typeof(DateTime) || tipo == typeof(decimal) || tipo == typeof(int))
                    tabla.Columns.Add(p.Name, tipo);
            }

            foreach (var item in items)
            {
                var valores = new object[tabla.Columns.Count];
                int i = 0;
                foreach (var p in props)
                {
                    if (tabla.Columns.Contains(p.Name))
                    {
                        valores[i] = p.GetValue(item);
                        i++;
                    }
                }
                tabla.Rows.Add(valores);
            }

            return tabla;
        }
    }
}
