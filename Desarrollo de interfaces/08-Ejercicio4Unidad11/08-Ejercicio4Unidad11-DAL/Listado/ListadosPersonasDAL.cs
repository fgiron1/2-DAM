
using _08_Ejercicio4Unidad11_DAL.Conexion;
using _08_Ejercicio4Unidad11_Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _08_Ejercicio4Unidad11_DAL.Listado
{
    public class ListadosPersonasDAL
    {

        /// <summary>
        /// Devuelve una lista con todas las persoans de la base de datos. Si no hay personas devolvera la lista vacia.
        /// </summary>
        /// <returns></returns>

        public List<ClsPersona> listadoPersonas()
        {
            List<ClsPersona> personas = new List<ClsPersona>();
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;
            SqlDataReader reader;
            ClsPersona persona;


            try
            {

                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand("SELECT ID,Nombre,Apellidos,FechaNacimiento,Foto,Direccion,Telefono,IDDepartamento FROM Personas", sqlConexion);

                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        persona = new ClsPersona();

                        persona.Id = (int)reader["ID"];

                        persona.Nombre = ((reader["Nombre"]) == System.DBNull.Value) ? "NULL" : (string)reader["Nombre"];

                        persona.Apellidos = ((reader["Apellidos"]) == System.DBNull.Value) ? "NULL" : (string)reader["Apellidos"];

                        persona.FechaNacimiento = ((reader["FechaNacimiento"]) == System.DBNull.Value) ? new DateTime() : (DateTime)reader["FechaNacimiento"];

                        persona.Foto = ((reader["Foto"]) == System.DBNull.Value) ? new byte[0] : (byte[])reader["Foto"];

                        persona.Direccion = ((reader["Direccion"]) == System.DBNull.Value) ? "NULL" : (string)reader["Direccion"];

                        persona.Telefono = ((reader["Telefono"]) == System.DBNull.Value) ? "NULL" : (string)reader["Telefono"];

                        persona.IdDepartamento = ((reader["IDDepartamento"]) == System.DBNull.Value) ? -1 : (int)reader["IDDepartamento"];

                        personas.Add(persona);

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


            return personas;

        }


        /// <summary>
        ///  Devuelve la persona que tenga el ID pasado por parametro. Si no hay ninguna persona devolvera null.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>

        public ClsPersona personaPorID(int ID)
        {
            ClsPersona persona = null;
            ClsConexion conexion = new ClsConexion();
            SqlConnection sqlConexion = new SqlConnection();
            SqlCommand sqlCommand;
            SqlDataReader reader;

            try
            {

                sqlConexion = conexion.getConnection();

                sqlCommand = new SqlCommand($"SELECT ID,Nombre,Apellidos,FechaNacimiento,Foto,Direccion,Telefono,IDDepartamento FROM Personas WHERE ID = {ID}", sqlConexion);

                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    persona = new ClsPersona();

                    persona.Id = (int)reader["ID"];

                    persona.Nombre = ((reader["Nombre"]) == System.DBNull.Value) ? "NULL" : (string)reader["Nombre"];

                    persona.Apellidos = ((reader["Apellidos"]) == System.DBNull.Value) ? "NULL" : (string)reader["Apellidos"];

                    persona.FechaNacimiento = ((reader["FechaNacimiento"]) == System.DBNull.Value) ? new DateTime() : (DateTime)reader["FechaNacimiento"];

                    persona.Foto = ((reader["Foto"]) == System.DBNull.Value) ? new byte[0] : (byte[])reader["Foto"];

                    persona.Direccion = ((reader["Direccion"]) == System.DBNull.Value) ? "NULL" : (string)reader["Direccion"];

                    persona.Telefono = ((reader["Telefono"]) == System.DBNull.Value) ? "NULL" : (string)reader["Telefono"];

                    persona.IdDepartamento = ((reader["IDDepartamento"]) == System.DBNull.Value) ? -1 : (int)reader["IDDepartamento"];

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


            return persona;

        }

    }
}
