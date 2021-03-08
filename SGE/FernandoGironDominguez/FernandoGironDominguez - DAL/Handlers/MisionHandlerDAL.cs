using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Connection;
using FernandoGironDominguez___Entities;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace FernandoGironDominguez___DAL.Handlers
{
    //All the fields are hardcoded, this code won't be able to handle changes on the database schema
    public class MisionHandlerDAL
    {
        public MyConnection connection { get; set; }

        //This field reflects the number of rows affected by the last instruction executed.
        //Helps debug code. (0 fields mean erroneous statement or no changes made,
        //                  -1 fields means no rows were read by a SELECT instruction)
        public int rowsAffected { get; set; }
        public MisionHandlerDAL()
        {
            this.connection = new MyConnection();
        }

        /// <summary>
        /// This method takes a Mision object as a parameter and
        /// updates the database mision record with the same ID
        /// </summary>
        /// <pre>id attribute </pre>
        /// <param name="newMision"></param>
        public void updateMision(Mision newMision)
        {

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Mision> PersonList = new List<Mision>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information, if any
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "UPDATE Misiones " +
                                              "SET nombre = @nombre, " +
                                              "descripcion = @descripcion, " +
                                              "creditos = @creditos, " +
                                              "completada = @completada " +
                                              "WHERE ID = @ID";


            connection.myCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = newMision.id;
            connection.myCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = newMision.nombre;
            connection.myCommand.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar).Value = newMision.descripcion;
            connection.myCommand.Parameters.Add("@creditos", System.Data.SqlDbType.Int).Value = newMision.creditos;
            connection.myCommand.Parameters.Add("@completada", System.Data.SqlDbType.Bit).Value = newMision.completada;

            //Executing non-query statement and passing the value of rows affected to our handler's property
            try
            {
                this.rowsAffected = connection.myCommand.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (SqlException e)
            {
                throw e;
            }

            //Closing connection
            this.connection.closeConnection();
        }

      
    }
}
