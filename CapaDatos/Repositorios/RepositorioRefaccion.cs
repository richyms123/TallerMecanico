using CapaDatos.Contratos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    /// <summary>
    /// Esta clase encapsula la lógica de acceso a datos para la entidad "Refaccion" en el sistema de gestión de taller mecánico,
    /// </summary>
    /// Esta clase implementa el contrato definido por la interfaz IRepositorioRefaccion, 
    /// proporcionando métodos para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) 
    /// y búsqueda de refacciones en la base de datos MySQL.
    public class RepositorioRefaccion : RepositorioMaestro, IRepositorioRefaccion
    {
        private readonly string seleccionarTodo;
        private readonly string agregar;
        private readonly string editar;
        private readonly string eliminar;
        private readonly string buscarPor;

        public RepositorioRefaccion()
        {
            seleccionarTodo = "SELECT * FROM Refacciones";
            agregar = @"INSERT INTO Refacciones(nombre,marca,precio_unitario,stock_actual,stock_minimo,proveedor)
              VALUES(@nombre,@marca,@precio_unitario,@stock_actual,@stock_minimo,@proveedor)";
            editar = @"UPDATE Refacciones SET nombre = @nombre, marca = @marca, precio_unitario = @precio_unitario,
              stock_actual = @stock_actual, stock_minimo = @stock_minimo, proveedor = @proveedor
              WHERE idRefaccion = @idRefaccion";
            eliminar = "DELETE FROM Refacciones WHERE idRefaccion = @idRefaccion";
            buscarPor = @"SELECT * FROM Refacciones WHERE nombre LIKE @texto OR 
            marca LIKE @texto OR proveedor LIKE @texto";

        }
        /// <summary>
        /// Añade una nueva refacción a la base de datos utilizando los parámetros proporcionados en el objeto "entidad".
        /// </summary>
        /// <param name="entidad">El objeto nuevo a agregar</param>
        /// <returns>Regresa el numero de filas afectadas</returns>
        public int Agregar(Refaccion entidad)
        {
            parametrosSql = new List<MySqlParameter>
            {
                new MySqlParameter("@nombre", entidad.nombre),
                new MySqlParameter("@marca", entidad.marca),
                new MySqlParameter("@precio_unitario", entidad.precioUnitario),
                new MySqlParameter("@stock_actual", entidad.stockActual),
                new MySqlParameter("@stock_minimo", entidad.stockMinimo),
                new MySqlParameter("@proveedor", entidad.proveedor)
            };
            return ExecuteNonQuery(agregar);
        }

        /// <summary>
        /// Edita una refacción existente en la base de datos utilizando los parámetros proporcionados en el objeto "entidad",
        /// </summary>
        /// <param name="entidad">El objeto a editar</param>
        /// <returns>Regresa el numero de filas afectadas</returns>
        public int Editar(Refaccion entidad)
        {
            parametrosSql = new List<MySqlParameter>
            {
                new MySqlParameter("@idRefaccion", entidad.idRefaccion),
                new MySqlParameter("@nombre", entidad.nombre),
                new MySqlParameter("@marca", entidad.marca),
                new MySqlParameter("@precio_unitario", entidad.precioUnitario),
                new MySqlParameter("@stock_actual", entidad.stockActual),
                new MySqlParameter("@stock_minimo", entidad.stockMinimo),
                new MySqlParameter("@proveedor", entidad.proveedor)
            };
            return ExecuteNonQuery(editar);
        }

        /// <summary>
        /// Elimina el registro de una refacción de la base de datos utilizando el identificador proporcionado en el parámetro "id",
        /// </summary>
        /// Hace una excepción si el id no existe en la base de datos, por lo que se recomienda verificar la existencia del registro antes de llamar a este método.
        /// <param name="id">El identificador unico del elemento a eliminar</param>
        /// <returns>El numero de filas afectadas por la operación de eliminar</returns>
        public int Eliminar(int id)
        {
            parametrosSql = new List<MySqlParameter>
            {
                new MySqlParameter("@idRefaccion", id)
            };
            return ExecuteNonQuery(eliminar);
        }


        /// <summary>
        /// Regresa todas las refacciones almacenadas en la base de datos, mapeando cada fila del resultado a un objeto "Refaccion" 
        /// y devolviendo una colección de estos objetos.
        /// </summary>
        /// Este metodo ejecuta una consulta SQL para seleccionar todas las refacciones, luego itera sobre los resultados y crea una instancia de "Refaccion" para cada fila
        /// <returns>Una coleccion de Refacciones que representan todos los registros encontrados</returns>
        public IEnumerable<Refaccion> ObtenerTodos()
        {
            DataTable resultado=ExecuteReader(seleccionarTodo);
            List<Refaccion> refacciones = new List<Refaccion>();
            foreach (DataRow row in resultado.Rows)
            {
                Refaccion refaccion = new Refaccion
                {
                    idRefaccion = Convert.ToInt32(row["idRefaccion"]),
                    nombre = row["nombre"].ToString(),
                    marca = row["marca"].ToString(),
                    precioUnitario = Convert.ToDecimal(row["precio_unitario"]),
                    stockActual = Convert.ToInt32(row["stock_actual"]),
                    stockMinimo = Convert.ToInt32(row["stock_minimo"]),
                    proveedor = row["proveedor"].ToString()
                };
                refacciones.Add(refaccion);
            }
            return refacciones;
        }

        /// <summary>
        /// Busca refacciones en la base de datos que coincidan con el texto proporcionado en los campos "nombre", "marca" o "proveedor".
        /// </summary>
        /// La búsqueda se realiza utilizando una consulta SQL con cláusulas LIKE para encontrar coincidencias parciales en los campos mencionados.
        /// <param name="texto">Es el texto a buscar </param>
        /// <returns>Un enumerable de Refacciones que contienen el texto especificado</returns>
        public IEnumerable<Refaccion> Buscar(string texto)
        {
            parametrosSql = new List<MySqlParameter>()
            {
                new MySqlParameter("@texto", "%" + texto + "%")
            };

            DataTable resultado = ExecuteReaderConParametros(buscarPor);
            List<Refaccion> refacciones = new List<Refaccion>();
            foreach (DataRow row in resultado.Rows)
            {
                Refaccion refaccion = new Refaccion
                {
                    idRefaccion = Convert.ToInt32(row["idRefaccion"]),
                    nombre = row["nombre"].ToString(),
                    marca = row["marca"].ToString(),
                    precioUnitario = Convert.ToDecimal(row["precio_unitario"]),
                    stockActual = Convert.ToInt32(row["stock_actual"]),
                    stockMinimo = Convert.ToInt32(row["stock_minimo"]),
                    proveedor = row["proveedor"].ToString()
                };
                refacciones.Add(refaccion);
            }
            return refacciones;
        }
    }
}
