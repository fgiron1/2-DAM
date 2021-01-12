using System;
using System.Data.SqlClient;

namespace _08_Ejercicio4Unidad11_DAL.Conexion
{
    class ClsConexion
    {

        public String server { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }


        public ClsConexion()
        {

            this.server = "fron99.database.windows.net";
            this.dataBase = "fron99";
            this.user = "fron99";
            this.pass = "Mitesoro1.";

        }


        public ClsConexion(String server, String database, String user, String pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }

        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión abierta con la base de datos</returns>

        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();

            try
            {

                connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }


        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>La conexion es cerrada</post>
        /// <param name="connection">SqlConnection pr referencia. Conexion a cerrar
        /// </param>

        public void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
