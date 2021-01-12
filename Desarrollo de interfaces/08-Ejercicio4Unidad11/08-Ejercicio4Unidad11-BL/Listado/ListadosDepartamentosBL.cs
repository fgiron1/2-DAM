using _08_Ejercicio4Unidad11_DAL.Listado;
using _08_Ejercicio4Unidad11_Entity;
using System.Collections.Generic;

namespace _08_Ejercicio4Unidad11_BL.Listado
{
    public class ListadosDepartamentosBL
    {

        /// <summary>
        /// Devuelve una lista con todos los departamentos de la base de datos. Si no hay departamentos devolvera la lista vacia.
        /// </summary>
        /// <returns></returns>

        public List<ClsDepartamento> listadoDepartamentos()
        {

            return new ListadosDepartamentosDAL().listadoDepartamentos();

        }


        /// <summary>
        /// Devuelve el departamento que tenga el ID pasado por parametro. Si no hay ningun departamento devolvera null.
        /// </summary>
        /// <returns></returns>

        public ClsDepartamento departamentoPorID(int ID)
        {

            return new ListadosDepartamentosDAL().departamentoPorID(ID); ;

        }

    }
}
