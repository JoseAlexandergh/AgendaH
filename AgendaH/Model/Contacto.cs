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

        
        public int PersonaId { get; set; }

        
        public string Tipo { get; set; }

        
        public string Valor { get; set; }

        
        public string NotasContacto { get; set; }
    }
}
