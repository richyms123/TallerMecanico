using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    /// <summary>
    /// Proporciona una clase base para la conexión a la base de datos MySQL en el sistema de gestión de taller mecánico,
    /// </summary>
    /// Esta clase encapsula la lógica de conexión a la base de datos, 
    /// permitiendo a los repositorios específicos heredar esta funcionalidad
    public abstract class RepositorioConexion
    {
        private readonly string cadenaConexion;

        public RepositorioConexion()
        {

            cadenaConexion = "Server=20.39.137.21;" +
                             "Port=3306;" +
                             "Database=TallerMecanico;" +
                             "Uid=richyms;" +
                             "Pwd=Elamlo110305;";
        }

        protected MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}
