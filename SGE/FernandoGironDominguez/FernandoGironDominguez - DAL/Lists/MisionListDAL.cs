using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Connection;
using FernandoGironDominguez___DAL.Handlers;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___DAL.Lists
{
    public class MisionListDAL
    {
        public MyConnection connection { get; set; }

        //This field reflects the number of rows affected by the last instruction executed.
        //Helps debug code. (0 fields mean erroneous statement or no changes made,
        //                  -1 fields means no rows were read by a SELECT instruction)
        public int rowsAffected { get; set; }
        public MisionListDAL()
        {
            this.connection = new MyConnection();
        }

        /// <summary>
        /// Devuelve la mision almacenada en la bbdd cuyo id coincide con el pasado por parametros
        /// </summary>
        /// <param name="id"></param>
        /// NOTA: Los nombres de las columnas están hardcoded; si cambia el esquema de la bbdd, habrá que cambiar las consultas
        /// <returns>Un objeto mision cuyo id coincide con el pasado por parametros</returns>
        public Mision getMision(int id)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection.myCommand = new SqlCommand();
            Mision readMision = new Mision();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "SELECT id, nombre, descripcion, creditos, completada" +
                                               "FROM dbo.Misiones " +
                                               "WHERE id = @id";


            connection.myCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                connection.myReader = connection.myCommand.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw e;
            }

            //Passing the value of rows affected to our handler's property
            //this.rowsAffected = connection.myReader.RecordsAffected;
            connection.myReader.Read();

            readMision.id = (int)connection.myReader["id"];
            readMision.nombre= (string)connection.myReader["nombre"];
            readMision.descripcion = (string)connection.myReader["descripcion"];
            readMision.creditos = (int)connection.myReader["creditos"];
            readMision.completada = (bool)connection.myReader["completada"];
            
            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();

            return readMision;

        }
        
        /// <summary>
        /// Devuelve la lista de todas las misiones almacenadas en la bbdd
        /// </summary>
        /// NOTA: Los nombres de las columnas están hardcoded; si cambia el esquema de la bbdd, habrá que cambiar las consultas
        /// <returns></returns>
        public List<Mision> getMisionList()
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection.myCommand = new SqlCommand();
            List<Mision> MisionList = new List<Mision>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader property -> Reader returns queried information
            
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "SELECT id, nombre, descripcion, creditos, completada FROM Misiones WHERE completada = 0";
            connection.myReader = connection.myCommand.ExecuteReader();
            

            if (connection.myReader.HasRows)
            {
                //Read method points to the next record.
                //It also returns true if it's pointing to a record and there are more left
                while (connection.myReader.Read())
                {

                    Mision readMision = new Mision();

                    readMision.id = (int)connection.myReader["id"];
                    readMision.nombre = (string)connection.myReader["nombre"];
                    readMision.descripcion = (string)connection.myReader["descripcion"];
                    readMision.creditos = (int)connection.myReader["creditos"];
                    readMision.completada = (bool)connection.myReader["completada"];

                    //Adding retrieved records to our MisionList
                    MisionList.Add(readMision);

                }
            }

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();

            return MisionList;

        }

    }
}
