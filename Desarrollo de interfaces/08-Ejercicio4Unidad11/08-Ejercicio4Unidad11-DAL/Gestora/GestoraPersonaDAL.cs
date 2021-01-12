using _08_Ejercicio4Unidad11_DAL.Conexion;
using _08_Ejercicio4Unidad11_Entity;
using System.Data.SqlClient;


namespace _08_Ejercicio4Unidad11_DAL.Gestora
{
     public class GestoraPersonaDAL
    {

        /// <summary>
        /// Elimina la persona con el ID pasado por parametro. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public int eliminarPersona(int ID)
        {
            int resultado = 0;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;

            try
            {
                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand($"DELETE FROM Personas WHERE ID = {ID}", sqlConexion);

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
        /// Añade la persona pasada por parametro a la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>

        public int anadirPersona(ClsPersona persona)
        {
            int resultado = 0;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand("set dateformat dmy", sqlConexion);

                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand($"INSERT INTO Personas (Nombre ,Apellidos ,FechaNacimiento ,Foto ,Direccion ,Telefono ,IDDepartamento) " +
                                            $"VALUES ('{persona.Nombre}' ,'{persona.Apellidos}' ,'{persona.FechaNacimiento}' ,@data ,'{persona.Direccion}' ,'{persona.Telefono}' ,{persona.IdDepartamento})", sqlConexion);

                if (persona.Foto != null)
                {
                    sqlCommand.Parameters.AddWithValue("@data", persona.Foto);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@data", new byte[0]);
                }
                

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
        /// Modifica la persona pasada por parametro a la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>

        public int modificarPersona(ClsPersona persona)
        {
            int resultado = 0;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;

            try
            {
                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand("set dateformat dmy", sqlConexion);

                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand($"UPDATE Personas " +
                                         $"SET Nombre = '{persona.Nombre}' ,Apellidos = '{persona.Apellidos}' ," +
                                         $"FechaNacimiento = '{persona.FechaNacimiento}' , Foto = @data ," +
                                         $"Direccion = '{persona.Direccion}' ,Telefono = '{persona.Telefono}' ," +
                                         $"IDDepartamento = {persona.IdDepartamento} " +
                                         $"WHERE ID = {persona.Id}", sqlConexion);

                if (persona.Foto != null)
                {
                    sqlCommand.Parameters.AddWithValue("@data", persona.Foto);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@data", new byte[0]);
                }


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
