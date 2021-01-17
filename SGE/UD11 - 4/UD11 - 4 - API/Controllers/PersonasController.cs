using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UD11___4___BL.Handlers;
using UD11___4___BL.Lists;
using UD11___4___Entities;

namespace UD11___4___API.Controllers
{
    public class PersonasController : ApiController
    {
        // GET: api/Personas
        public IEnumerable<Person> Get()
        {
            List<Person> lista = null;

            try
            {
                PersonListBL handler = new PersonListBL();
                lista = handler.getPersonList();
            }
            catch(Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            return lista;
        }

        // GET: api/Personas/5
        public Person Get(int id)
        {
            Person oPersona = null;

            try
            {
                PersonListBL handler = new PersonListBL();
                oPersona = handler.getPersonById(id);
            }catch(Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
           
            

            return oPersona;
        }

        // POST: api/Personas
        public void Post([FromBody]Person personaNueva)
        {
            try
            {
                PersonHandlerBL handler = new PersonHandlerBL();
                handler.insertPerson(personaNueva);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            } 

            
        }

        // PUT: api/Personas/5
        public void Put(int id, [FromBody]Person personaActualizada)
        {

        }

        // DELETE: api/Personas/5
        public void Delete(int id)
        {
            PersonHandlerBL handler = new PersonHandlerBL();
            handler.deletePerson(id);

        }
    }
}
