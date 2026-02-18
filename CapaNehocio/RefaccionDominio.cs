using CapaDatos;
using CapaDatos.Contratos;
using CapaDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNehocio
{
    public class RefaccionDominio
    {

        private IRepositorioRefaccion repositorioRefaccion;
        public RefaccionDominio()
        {
            repositorioRefaccion = new RepositorioRefaccion();
        }

        public List<Refaccion> ObtenerRefacciones()
        {
            return repositorioRefaccion.ObtenerTodos().ToList();
        }

        public string AgregarRefaccion(Refaccion refaccion)
        {
            try
            {
                string mensajeValidacion = ValidarRefaccion(refaccion);
                if (!string.IsNullOrEmpty(mensajeValidacion))
                {
                    return mensajeValidacion;
                }

                int filasAfectadas = repositorioRefaccion.Agregar(refaccion);
                if (filasAfectadas > 0)
                {
                    return "Refacción agregada exitosamente.";
                }
                else
                {
                    return "Error al agregar la refacción.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al agregar la refacción: {ex.Message}";
            }
            
        }

        public string ActualizarRefaccion(Refaccion refaccion)
        {
            try
            {
                string mensajeValidacion = ValidarRefaccion(refaccion);
                if (!string.IsNullOrEmpty(mensajeValidacion))
                {
                    return mensajeValidacion;
                }
                int filasAfectadas = repositorioRefaccion.Editar(refaccion);
                if (filasAfectadas > 0)
                {
                    return "Refacción actualizada exitosamente.";
                }
                else
                {
                    return "Error al actualizar la refacción.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al actualizar la refacción: {ex.Message}";
            }
           
        }

        public string EliminarRefaccion(int idRefaccion)
        {
            try
            {
                int filasAfectadas = repositorioRefaccion.Eliminar(idRefaccion);
                if (filasAfectadas > 0)
                {
                    return "Refacción eliminada exitosamente.";
                }
                else
                {
                    return "Error al eliminar la refacción.";
                }
            }
            catch (Exception e) {

                return "No se puede eliminar la refacción porque existen órdenes de refacción asociadas a ella.";
            }
            
        }

        public List<Refaccion> BuscarRefaccion(string Busqueda)
        {
            return repositorioRefaccion.Buscar(Busqueda).ToList();
        }


        public string ValidarRefaccion(Refaccion refaccion)
        {
            if (string.IsNullOrEmpty(refaccion.nombre))
            {
                return "El nombre de la refacción es obligatorio.";
            }
            if (string.IsNullOrEmpty(refaccion.marca))
            {
                return "La marca de la refacción es obligatoria.";
            }
            if (refaccion.precioUnitario <= 0)
            {
                return "El precio unitario debe ser mayor a cero.";
            }
            if (refaccion.stockActual < 0)
            {
                return "El stock actual no puede ser negativo.";
            }
            if (refaccion.stockMinimo < 0)
            {
                return "El stock mínimo no puede ser negativo.";
            }
            if (string.IsNullOrEmpty(refaccion.proveedor))
            {
                return "El proveedor de la refacción es obligatorio.";
            }
            return string.Empty;


        }
    }
}
