using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaH.Model
{
    // Clase que representa un registro en la tabla Contactos
    public class Contacto
    {
        public int Id { get; set; }

        // Campo clave para la relación (ForeignKey)
        public int PersonaId { get; set; }

        // Coincide con el campo Tipo de tu tabla SQL
        public string Tipo { get; set; }

        // Coincide con el campo Valor de tu tabla SQL
        public string Valor { get; set; }

        // Propiedad para notas, aunque no se usa en el CRUD base
        public string NotasContacto { get; set; }
    }
}
