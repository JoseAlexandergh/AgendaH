using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaH.Repository
{
    // T: tipo de entidad (Persona, Contacto, Cita)
    public interface IRepository<T>
    {
        // Métodos CRUD
        void Save(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);

        // Colecciones + LINQ
        List<T> GetAll();
    }
}