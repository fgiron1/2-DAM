using _08_Ejercicio4Unidad11_DAL.Gestora;
using _08_Ejercicio4Unidad11_Entity;

namespace _08_Ejercicio4Unidad11_BL.Gestora
{
    public class GestoraDepartamentoBL
    {

        /// <summary>
        /// Elimina el departamento con el ID pasado por parametro. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public int eliminarDepartamento(int ID)
        {
            return new GestoraDepartamentoDAL().eliminarDepartamento(ID);

        }

        /// <summary>
        /// Añade el departamento pasada por parametro a la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>

        public int anadirDepartamento(ClsDepartamento departamento)
        {

            return new GestoraDepartamentoDAL().anadirDepartamento(departamento); ;

        }


        /// <summary>
        /// Modifica el departamento pasado por parametro de la base de datos. Devuelve la cantidad de filas afectadas.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>

        public int modificarDepartamento(ClsDepartamento departamento)
        {

            return new GestoraDepartamentoDAL().modificarDepartamento(departamento);

        }

    }
}
