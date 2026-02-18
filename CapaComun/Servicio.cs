using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    /// <summary>
    /// Representa un servicio en el sistema de gestión de taller mecánico, con propiedades como 
    /// id, nombre, descripción, costo base y tiempo estimado para su realización.
    /// </summary>
    public class Servicio
    {
        public int idServicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costoBase { get; set; }
        public int tiempoEstimado { get; set; } 
    }
}
