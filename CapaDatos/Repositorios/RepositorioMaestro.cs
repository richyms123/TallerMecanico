using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    /// <summary>
    /// Esta clase proporciona métodos comunes para ejecutar consultas SQL y comandos en la base de datos MySQL,
    /// </summary>
    /// Esta clase sirve como base para los repositorios específicos de servicios y refacciones, 
    /// permitiendo la reutilización de código para la ejecución de consultas y comandos SQL.
    public class RepositorioMaestro : RepositorioConexion
    {
        protected List<MySqlParameter> parametrosSql;

        protected int ExecuteNonQuery(string querySql)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(querySql, conexion))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = querySql;
                    foreach (MySqlParameter paramentro in parametrosSql)
                    {
                        comando.Parameters.Add(paramentro);
                    }
                    int filasAfectadas = comando.ExecuteNonQuery();
                    parametrosSql.Clear();
                    return filasAfectadas;
                }
            }
        }

        protected DataTable ExecuteReader(string querySql)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(querySql, conexion))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = querySql;
                    MySqlDataReader lector = comando.ExecuteReader();
                    using (DataTable tabla = new DataTable())
                    {
                        tabla.Load(lector);
                        lector.Dispose();
                        return tabla;
                    }

                }
            }
        }

        protected DataTable ExecuteReaderConParametros(string querySql)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(querySql, conexion))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = querySql;
                    if(parametrosSql != null && parametrosSql.Count > 0)
                    {
                        foreach (MySqlParameter paramentro in parametrosSql)
                        {
                            comando.Parameters.Add(paramentro);
                        }
                    }
                    MySqlDataReader lector = comando.ExecuteReader();
                    using (DataTable tabla = new DataTable())
                    {
                        tabla.Load(lector);
                        lector.Dispose();
                        parametrosSql.Clear();
                        return tabla;
                    }

                }
            }
        }
    }
}
