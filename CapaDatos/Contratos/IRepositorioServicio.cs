using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Contratos
{
    /// <summary>
    /// Define un contrato específico para la gestión de servicios en el sistema de gestión de taller mecánico,
    /// y hereda de la interfaz genérica IRepositorioGenerico para proporcionar operaciones CRUD básicas,
    /// </summary>
    public interface IRepositorioServicio : IRepositorioGenerico<Servicio>
    {
        IEnumerable<Servicio> Buscar(string busqueda);
    }
}
