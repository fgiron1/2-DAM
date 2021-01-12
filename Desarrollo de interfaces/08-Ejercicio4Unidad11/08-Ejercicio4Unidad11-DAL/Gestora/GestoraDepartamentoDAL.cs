using _08_Ejercicio4Unidad11_DAL.Conexion;
using _08_Ejercicio4Unidad11_Entity;
using System.Data.SqlClient;

namespace _08_Ejercicio4Unidad11_DAL.Gestora
{
    public class GestoraDepartamentoDAL
    {

        /// <summary>
        /// Elimina el departamento con el ID pasado por parametro. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public int eliminarDepartamento(int ID)
        {
            int resultado = 0;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection(); ;
            SqlCommand sqlCommand;

            try
            {
                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand($"DELETE FROM Departamentos WHERE ID = {ID}", sqlConexion);

                resultado = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConexion);
            }

            return resultado;

        }

        /// <summary>
        /// Añade el departamento pasada por parametro a la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>

        public int anadirDepartamento(ClsDepartamento departamento)
        {
            int resultado = 0;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;

            try
            {
                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand($"INSERT INTO Departamentos (Nombre) " +
                                         $"VALUES ('{departamento.Nombre}')", sqlConexion);

                resultado = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConexion);
            }


            return resultado;

        }


        /// <summary>
        /// Modifica el departamento pasado por parametro de la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>

        public int modificarDepartamento(ClsDepartamento departamento)
        {
            int resultado = 0;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;

            try
            {
                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand($"UPDATE Departamentos " +
                                         $"SET Nombre = '{departamento.Nombre}' " +
                                         $"WHERE ID = {departamento.Id}", sqlConexion);

                resultado = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.closeConnection(ref sqlConexion);
            }


            return resultado;

        }

    }
}
