using _08_Ejercicio4Unidad11_DAL.Conexion;
using _08_Ejercicio4Unidad11_Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _08_Ejercicio4Unidad11_DAL.Listado
{
    public class ListadosDepartamentosDAL
    {

        /// <summary>
        /// Devuelve una lista con todos los departamentos de la base de datos. Si no hay departamentos devolvera la lista vacia.
        /// </summary>
        /// <returns></returns>

        public List<ClsDepartamento> listadoDepartamentos()
        {
            List<ClsDepartamento> departamentos = new List<ClsDepartamento>();
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;
            SqlDataReader reader;
            ClsDepartamento departamento;


            try
            {

                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand("SELECT ID,Nombre FROM Departamentos", sqlConexion);

                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        departamento = new ClsDepartamento();

                        departamento.Id = (int)reader["ID"];

                        departamento.Nombre = ((reader["Nombre"]) == System.DBNull.Value) ? "NULL" : (string)reader["Nombre"];

                        departamentos.Add(departamento);

                    }

                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConexion);
            }


            return departamentos;

        }


        /// <summary>
        /// Devuelve el departamento que tenga el ID pasado por parametro. Si no hay ningun departamento devolvera null.
        /// </summary>
        /// <returns></returns>

        public ClsDepartamento departamentoPorID(int ID)
        {
            ClsDepartamento departamento = null;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;
            SqlDataReader reader;

            try
            {

                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand($"SELECT ID,Nombre FROM Departamentos WHERE ID = {ID}", sqlConexion);

                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    departamento = new ClsDepartamento();

                    departamento.Id = (int)reader["ID"];

                    departamento.Nombre = ((reader["Nombre"]) == System.DBNull.Value) ? "NULL" : (string)reader["Nombre"];

                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConexion);
            }


            return departamento;

        }


    }
}
