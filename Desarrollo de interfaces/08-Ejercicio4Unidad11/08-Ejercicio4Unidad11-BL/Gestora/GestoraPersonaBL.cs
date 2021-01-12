using _08_Ejercicio4Unidad11_DAL.Gestora;
using _08_Ejercicio4Unidad11_Entity;

namespace _08_Ejercicio4Unidad11_BL.Gestora
{
    public class GestoraPersonaBL
    {


        /// <summary>
        /// Elimina la persona con el ID pasado por parametro. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public int eliminarPersona(int ID)
        {

            return new GestoraPersonaDAL().eliminarPersona(ID);

        }

        /// <summary>
        /// Añade la persona pasada por parametro a la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>

        public int anadirPersona(ClsPersona persona)
        {

            return new GestoraPersonaDAL().anadirPersona(persona);

        }


        /// <summary>
        /// Modifica la persona pasada por parametro a la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>

        public int modificarPersona(ClsPersona persona)
        {

            return new GestoraPersonaDAL().modificarPersona(persona);

        }


    }
}
