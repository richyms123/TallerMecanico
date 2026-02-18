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
    public class ServicioDominio
    {
        private IRepositorioServicio repositorioServicio;

        public ServicioDominio()
        {
            repositorioServicio = new RepositorioServicio();
        }

        public List<Servicio> ObtenerServicios()
        {
            return repositorioServicio.ObtenerTodos().ToList();
        }

        public string AgregarServicio(Servicio servicio)
        {
            try
            {
                string mensajeValidacion = ValidarServicio(servicio);
                if (!string.IsNullOrEmpty(mensajeValidacion))
                {
                    return mensajeValidacion;
                }
                int filasAfectadas = repositorioServicio.Agregar(servicio);
                if (filasAfectadas > 0)
                {
                    return "Servicio agregado exitosamente.";
                }
                else
                {
                    return "Error al agregar el servicio.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al agregar el servicio: {ex.Message}";
            }
        }

        public string ActualizarServicio(Servicio servicio)
        {
            try
            {
                string mensajeValidacion = ValidarServicio(servicio);
                if (!string.IsNullOrEmpty(mensajeValidacion))
                {
                    return mensajeValidacion;
                }
                int filasAfectadas = repositorioServicio.Editar(servicio);
                if (filasAfectadas > 0)
                {
                    return "Servicio actualizado exitosamente.";
                }
                else
                {
                    return "Error al actualizar el servicio.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el servicio: {ex.Message}";
            }
        }

        public string EliminarServicio(int id)
        {
            try
            {
                int filasAfectadas = repositorioServicio.Eliminar(id);
                if (filasAfectadas > 0)
                {
                    return "Servicio eliminado exitosamente.";
                }
                else
                {
                    return "Error al eliminar el servicio.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el servicio: {ex.Message}";
            }
        }

        public List<Servicio> BuscarServicios(string busqueda)
            {
                return repositorioServicio.Buscar(busqueda).ToList();
        }

        public string ValidarServicio(Servicio servicio)
        {
            if (string.IsNullOrWhiteSpace(servicio.nombre))
            {
                return "El nombre del servicio es obligatorio.";
            }
            if (servicio.costoBase < 0)
            {
                return "El costo base no puede ser negativo.";
            }
            if (servicio.tiempoEstimado < 0)
            {
                return "El tiempo estimado no puede ser negativo.";
            }
            return string.Empty;
        }




    }
}
