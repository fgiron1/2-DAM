using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UD11___4___API.Models;
using UD11___4___BL.Handlers;
using UD11___4___BL.Lists;
using UD11___4___Entities;

namespace UD11___4___API.Controllers
{

    //Este controller no tiene metodos para manejar los verbos PUT, POST ni DELETE porque 
    //es empleado para presentar la misma información que el controlador de Personas, salvo
    //que en un formato distinto

    public class PersonasDepartmentNameController : ApiController
    {
        // GET: api/PersonasDepartmentName
        public HttpResponseMessage Get()
        {
            List<PersonDepartmentName> lista = new List<PersonDepartmentName>();
            HttpResponseMessage respuesta;

            try
            {
                PersonListBL personListHandler = new PersonListBL();
                DepartmentListBL departmentListHandler = new DepartmentListBL();

                //Obtenemos la lista de personas sin el nombre de departamento
                //y en cada iteración del bucle, usamos cada una de las personas para
                //instanciar un nuevo objeto PersonDepartmentName y añadirlo a la lista
                //que vamos a devolver

                foreach (Person p in personListHandler.getPersonList())
                {
                    lista.Add(new PersonDepartmentName(p, departmentListHandler.getDepartmentById(p.DepartmentID).Name));
                }

            }
            catch (HttpResponseException e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            finally
            {
                if (lista == null)
                {
                    //Según el estándar http, NO se debe incluir contenido
                    //en las respuestas http de no content
                    respuesta = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {


                    respuesta = Request.CreateResponse(HttpStatusCode.OK, lista);
                }
            }

            return respuesta;
        }

        // GET: api/PersonasDepartmentName/5
        public HttpResponseMessage Get(int id)
        {
            PersonDepartmentName oPersonaNombre = null;
            HttpResponseMessage respuesta;

            try
            {
                PersonListBL personListHandler = new PersonListBL();
                DepartmentListBL departmentListHandler = new DepartmentListBL();

                //Obtenemos la persona solicitada sin el nombre de departamento
                //y la usamos para instanciar un objeto PersonDepartmentName,
                //junto con el nombre de departamento que le corresponde a la id de departamento

                Person oPersonaSinNombre = personListHandler.getPersonById(id);

                //Obtenemos la lista de personas sin el nombre de departamento
                //y en cada iteración del bucle, usamos cada una de las personas para
                //instanciar un nuevo objeto PersonDepartmentName y añadirlo a la lista
                //que vamos a devolver

                oPersonaNombre = new PersonDepartmentName(oPersonaSinNombre,
                    //Obteniendo el nombre de departamento a partir de la id
                    departmentListHandler.getDepartmentById(oPersonaSinNombre.DepartmentID).Name);

            }
            catch (HttpResponseException e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            finally
            {
                if (oPersonaNombre == null)
                {
                    //Según el estándar http, NO se debe incluir contenido
                    //en las respuestas http de no content
                    respuesta = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {


                    respuesta = Request.CreateResponse(HttpStatusCode.OK, oPersonaNombre);
                }
            }

            return respuesta;
        }

        /*
        // POST: api/PersonasDepartmentName
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PersonasDepartmentName/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PersonasDepartmentName/5
        public void Delete(int id)
        {
        }*/
    }
}
