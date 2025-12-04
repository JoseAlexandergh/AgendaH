using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaH.Model
{
    // Clase que representa un registro en la tabla Citas
    public class Cita
    {
        public int ID { get; set; }
        public int PersonaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string NombrePersona { get; set; }
    }
}

