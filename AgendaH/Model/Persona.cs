using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AgendaH.Model
{
    // Clase que representa un registro en la base de datos (Entidad Personas)
    public class Persona
    {
        // Encapsulamiento con propiedades (get/set)
        public int ID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Notas { get; set; }

        public Persona()
        {
            FechaNacimiento = DateTime.Now;
        }

        // Propiedad calculada para mostrar en ComboBoxes o DataGrids
        public string GetNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
