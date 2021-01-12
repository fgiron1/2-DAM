using _08_Ejercicio4Unidad11_DAL.Listado;
using _08_Ejercicio4Unidad11_Entity;
using System.Collections.Generic;

namespace _08_Ejercicio4Unidad11_BL.Listado
{
    public class ListadosPersonasBL
    {

        /// <summary>
        /// Devuelve una lista con todas las persoans de la base de datos. Si no hay personas devolvera la lista vacia.
        /// </summary>
        /// <returns></returns>

        public List<ClsPersona> listadoPersonas()
        {

            return new ListadosPersonasDAL().listadoPersonas();

        }


        /// <summary>
        ///  Devuelve la persona que tenga el ID pasado por parametro. Si no hay ninguna persona devolvera null.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>

        public ClsPersona personaPorID(int ID)
        {

            return new ListadosPersonasDAL().personaPorID(ID);

        }

    }
}
