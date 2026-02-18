using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    /// <summary>
    /// Representa una refacción en el sistema de gestión de taller mecánico, con propiedades como 
    /// id, nombre, marca, precio unitario, stock actual, stock mínimo y proveedor.
    /// </summary>
    public class Refaccion
    {
        public int idRefaccion { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public decimal precioUnitario { get; set; }
        public int stockActual { get; set; }
        public int stockMinimo { get; set; }
        public string proveedor { get; set; }
    }
}
