using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Contratos
{
    /// <summary>
    /// Esta interfaz define un contrato genérico para operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en entidades de tipo "Entity".
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IRepositorioGenerico<Entity> where Entity : class
    {
        int Agregar(Entity entidad);
        int Editar(Entity entidad);
        int Eliminar(int id);
        IEnumerable<Entity> ObtenerTodos();
    }
}
