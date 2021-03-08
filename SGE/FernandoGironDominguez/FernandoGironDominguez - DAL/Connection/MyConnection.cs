using System;
using System.Data.SqlClient;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _server: cadena 
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace FernandoGironDominguez___DAL.Connection

{
    public class MyConnection
    {
        //Atributos
        public String server { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        //These three properties need to be instantiated whenever a MyConnection object is used
        public SqlDataReader myReader { get; set; }
        public SqlCommand myCommand { get; set; }
        public SqlConnection myConnection { get; set; }

        //Constructores

        public MyConnection()
        {
            this.server = "localhost";
            this.dataBase = "Mandalorian";
            this.user = "prueba1";            
            this.pass = "prueba123";
        }

        //Con parámetros por si quisiera cambiar las conexiones
        public MyConnection(String server, String database, String user, String pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }


        //METODOS

        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión abierta con la base de datos</returns>
        public void openConnection()
        {
            this.myConnection = new SqlConnection();

            try
            { 
                this.myConnection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                this.myConnection.Open();
            }
            catch (SqlException e)
            {
                throw e;
            }

        }




        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>La conexion es cerrada</post>
        /// <param name="connection">SqlConnection pr referencia. Conexion a cerrar</param>
        public void closeConnection()
        {
            try
            {
                this.myConnection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}
