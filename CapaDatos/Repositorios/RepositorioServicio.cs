using CapaDatos.Contratos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    /// <summary>
    /// Proporciona metodos específicos para la gestión de servicios en el sistema de gestión de taller mecánico
    /// </summary>
    /// Esta clase interactúa con la base de datos MySQL para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar)
    public class RepositorioServicio : RepositorioMaestro, IRepositorioServicio
    {
        private readonly string seleccionarTodo;
        private readonly string agregar;
        private readonly string editar;
        private readonly string eliminar;
        private readonly string buscarPor;

        public RepositorioServicio()
        {
            seleccionarTodo = "SELECT * FROM Servicios";
            agregar = "INSERT INTO Servicios (nombre_servicio, descripcion, costo_base, tiempo_estimado_hrs) VALUES (@nombre, @descripcion, @costoBase, @tiempoEstimado)";
            editar = "UPDATE Servicios SET nombre_servicio = @nombre, descripcion = @descripcion, costo_base = @costoBase, tiempo_estimado_hrs = @tiempoEstimado WHERE idServicio = @idServicio";
            eliminar = "DELETE FROM Servicios WHERE idServicio = @idServicio";
            buscarPor = "SELECT * FROM Servicios WHERE nombre_servicio LIKE @busqueda OR descripcion LIKE @busqueda";
        }

        /// <summary>
        /// Agrega un nuevo servicio a la base de datos. Retorna el número de filas afectadas, lo que indica si la operación fue exitosa o no.
        /// </summary>
        /// <param name="entidad">La entidad Servicio a agregar</param>
        /// <returns>El numero de filas afectadas despues del insert</returns>
        public int Agregar(Servicio entidad)
        {
            parametrosSql = new List<MySqlParameter>()
            {
                new MySqlParameter("@nombre", entidad.nombre),
                new MySqlParameter("@descripcion", entidad.descripcion),
                new MySqlParameter("@costoBase", entidad.costoBase),
                new MySqlParameter("@tiempoEstimado", entidad.tiempoEstimado)
            };
            return ExecuteNonQuery(agregar);
        }

        /// <summary>
        /// Busca servicios en la base de datos que coincidan con el término de búsqueda proporcionado. Retorna una colección de servicios que cumplen con el criterio de búsqueda, 
        /// permitiendo a los usuarios encontrar servicios específicos por nombre o descripción.
        /// </summary>
        /// <param name="busqueda">El texto definido para filtrar los servicios</param>
        /// <returns>Regresa un enumerable que representa los elementos que cumplieron con el criterio de busqueda</returns>
        public IEnumerable<Servicio> Buscar(string busqueda)
        {
            parametrosSql = new List<MySqlParameter>()
            {
                new MySqlParameter("@busqueda","%"+busqueda+"%")
            };
            DataTable resultado = ExecuteReaderConParametros(buscarPor);
            List<Servicio> servicios = new List<Servicio>();
            foreach (DataRow row in resultado.Rows)
            {
                servicios.Add(new Servicio
                {
                    idServicio = Convert.ToInt32(row["idServicio"]),
                    nombre = row["nombre_servicio"].ToString(),
                    descripcion = row["descripcion"].ToString(),
                    costoBase = Convert.ToDecimal(row["costo_base"]),
                    tiempoEstimado = Convert.ToInt32(row["tiempo_estimado_hrs"])
                });
            }
            return servicios;
        }

        /// <summary>
        /// Edita un servicio existente en la base de datos. Retorna el número de filas afectadas, lo que indica si la operación fue exitosa o no.
        /// </summary>
        /// <param name="entidad">El objeto servicio a editar</param>
        /// <returns>El numero de filas afectadas</returns>
        public int Editar(Servicio entidad)
        {
            parametrosSql = new List<MySqlParameter>()
            {
                new MySqlParameter("@idServicio", entidad.idServicio),
                new MySqlParameter("@nombre", entidad.nombre),
                new MySqlParameter("@descripcion", entidad.descripcion),
                new MySqlParameter("@costoBase", entidad.costoBase),
                new MySqlParameter("@tiempoEstimado", entidad.tiempoEstimado)
            };
            return ExecuteNonQuery(editar);
        }

        /// <summary>
        /// Elimina un servicio de la base de datos utilizando su identificador único. Retorna el número de filas afectadas, 
        /// lo que indica si la operación fue exitosa o no.
        /// </summary>
        /// <param name="id">El id que identifica al registro a eliminar</param>
        /// <returns>El numero de filas afectadas despues de la eliminacion</returns>
        public int Eliminar(int id)
        {
            parametrosSql = new List<MySqlParameter>()
            {
                new MySqlParameter("@idServicio", id)
            };
            return ExecuteNonQuery(eliminar);
        }


        /// <summary>
        /// Regresa una colección de todos los servicios disponibles en la base de datos. Este método es fundamental para mostrar la lista completa de servicios a los usuarios,
        /// </summary>
        /// <returns>Regresa todos los elementos del bd</returns>
        public IEnumerable<Servicio> ObtenerTodos()
        {
            DataTable resultado = ExecuteReader(seleccionarTodo);
            List<Servicio> servicios = new List<Servicio>();
            foreach (DataRow row in resultado.Rows)
            {
                servicios.Add(new Servicio
                {
                    idServicio = Convert.ToInt32(row["idServicio"]),
                    nombre = row["nombre_servicio"].ToString(),
                    descripcion = row["descripcion"].ToString(),
                    costoBase = Convert.ToDecimal(row["costo_base"]),
                    tiempoEstimado = Convert.ToInt32(row["tiempo_estimado_hrs"])
                });
            }
            return servicios;
        }
    }
}
